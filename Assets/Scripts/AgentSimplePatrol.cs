using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentSimplePatrol : MonoBehaviour
{
    //Activate if agent should wait on point
    [SerializeField] bool shouldWaitOnPoint;

    //Total wait time on each point
    [SerializeField] float waitTimeOnPoint;

    //Probability to change direction of patrol
    [SerializeField] float _switchDirectionProbability = 0.2f;

    [SerializeField] List<PatrolPoint> patrolPoints;

    private NavMeshAgent _navMeshAgent;
    private int _currentPointIndex;
    private bool _isAgentTraveling;
    private bool _isAgentWaiting;
    private bool _isGoindForward;
    private float _waitTimer;

    // Player info
    private float _runSpeedOnDetect = 10f;

    [HideInInspector] public bool _isPlayerDetected;
    [HideInInspector] public Transform _playerTransform;

    private GameObject _myGameController;

    public void Start()
    {
        _myGameController = GameObject.FindGameObjectWithTag("GameController");

        _navMeshAgent = GetComponent<NavMeshAgent>();

        if (_navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent component is required");
        }
        else
        {
            if (patrolPoints != null && patrolPoints.Count >= 2)
            {
                _currentPointIndex = 0;
                SetNextDestination();
            }
            else
            {
                Debug.LogWarning("You should specify almost 2 patrol points");
            }
        }
    }

    public void Update()
    {
        if (!CheckIfGameOver())
        {
            if (_isPlayerDetected)
            {
                ChangeTargetToPlayer();
            }
            else
            {
                if (_isAgentTraveling && _navMeshAgent.remainingDistance <= 1.0f)
                {
                    _isAgentTraveling = false;
                    if (shouldWaitOnPoint)
                    {
                        _isAgentWaiting = true;
                        _waitTimer = 0f;
                    }
                    else
                    {
                        ChangePatrolPoint();
                        SetNextDestination();
                    }
                }

                if (_isAgentWaiting)
                {
                    _waitTimer += Time.deltaTime;
                    if (_waitTimer >= waitTimeOnPoint)
                    {
                        _isAgentWaiting = false;
                        ChangePatrolPoint();
                        SetNextDestination();
                    }
                }
            }
        }
    }

    private bool CheckIfGameOver()
    {
        return _myGameController.GetComponent<MyGameController>().isGameOver;
    }

    /// <summary>
    /// Switch to next patrol point, forward or backward
    /// </summary>
    private void ChangePatrolPoint()
    {
        if (Random.Range(0f, 1f) <= _switchDirectionProbability)
        {
            _isGoindForward = !_isGoindForward;
        }

        if (_isGoindForward)
        {
            _currentPointIndex = (_currentPointIndex + 1) % patrolPoints.Count;
        }
        else
        {
            if (--_currentPointIndex < 0)
            {
                _currentPointIndex = patrolPoints.Count - 1;
            }
        }
    }

    private void ChangeTargetToPlayer()
    {
        _navMeshAgent.SetDestination(_playerTransform.position);
        _navMeshAgent.speed = 10f;
    }

    private void SetNextDestination()
    {
        if (patrolPoints != null)
        {
            Vector3 nextDestination = patrolPoints[_currentPointIndex].transform.position;
            _navMeshAgent.SetDestination(nextDestination);
            _isAgentTraveling = true;
        }
    }
}