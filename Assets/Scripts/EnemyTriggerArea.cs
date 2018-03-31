using UnityEngine;
using UnityEngine.AI;

public class EnemyTriggerArea : MonoBehaviour
{

	[SerializeField] private Transform playerPosition;
	[SerializeField] private Transform _restartPointPatrol;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{

			this.GetComponentInParent<AgentSimplePatrol>()._isPlayerDetected = true;
			this.GetComponentInParent<AgentSimplePatrol>()._playerTransform = playerPosition;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			this.GetComponentInParent<AgentSimplePatrol>()._isPlayerDetected = false;
			this.GetComponentInParent<AgentSimplePatrol>()._playerTransform = null;
			this.GetComponentInParent<NavMeshAgent>().speed = 7f;
		}
	}
}
