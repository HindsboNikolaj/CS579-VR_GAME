using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManipulator : MonoBehaviour
{
    [SerializeField] GameObject targetObject;
    [SerializeField] float gravity = -9.81f;
    private Rigidbody targetRb;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = targetObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        targetRb.AddForce(transform.up * gravity);
    }
}
