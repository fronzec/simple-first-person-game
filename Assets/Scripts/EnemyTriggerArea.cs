using UnityEngine;
using UnityEngine.AI;

//Check if player is detected using view-like detection
public class EnemyTriggerArea : MonoBehaviour
{
	[SerializeField] private Transform _restartPointPatrol;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{

			this.GetComponentInParent<AgentSimplePatrol>()._isPlayerDetected = true;
			this.GetComponentInParent<AgentSimplePatrol>()._playerTransform = other.transform;
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
