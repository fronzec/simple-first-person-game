using UnityEngine;

public class PatrolPoint : MonoBehaviour
{
    [SerializeField] protected float debugDrawRadius = 1.0f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, debugDrawRadius);
    }
}