using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToStart : MonoBehaviour
{
    public float heightBoundary = -10;
    
    private Vector3 startPos;
    private Quaternion startRot;
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < heightBoundary) {
            rb.velocity = Vector3.zero;
            transform.position = startPos;
            transform.rotation = startRot;
        }
    }
}
