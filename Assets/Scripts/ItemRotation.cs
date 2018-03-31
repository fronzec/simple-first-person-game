using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotation : MonoBehaviour
{
    [SerializeField] private float _rotateAngle;

    Transform transform;

    // Use this for initialization
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(0, _rotateAngle * Time.deltaTime, 0);
    }
}