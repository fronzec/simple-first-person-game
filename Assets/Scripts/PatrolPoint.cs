using UnityEngine;

//This script is used to draw on editor the Patrol Points
public class PatrolPoint : MonoBehaviour
{
    [SerializeField] protected float debugDrawRadius = 1.0f;

    //Used to draw patrol points on editor 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, debugDrawRadius);
    }
}