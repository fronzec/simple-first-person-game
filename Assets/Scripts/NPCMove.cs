using UnityEngine;
using UnityEngine.AI;

//Test of NPC simple move NOT USED IN GAME
public class NPCMove : MonoBehaviour
{
    [SerializeField] private Transform _destination;

    private NavMeshAgent _navMeshAgent;

    // Use this for initialization
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        if (_navMeshAgent == null)
        {
            Debug.Log("The Navmesh component is required");
        }
        else
        {
            SetAgentDestination();
        }
    }

    private void SetAgentDestination()
    {
        Vector3 targetDestination = _destination.transform.position;
        _navMeshAgent.SetDestination(targetDestination);
    }
}