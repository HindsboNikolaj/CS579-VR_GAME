using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public GameObject exitPortal;
    public bool playerCanTeleport = true;

    private Vector3 portalOffset;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        if (exitPortal != null) {
            portalOffset = exitPortal.transform.forward * 3;
        }
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {}

    void OnTriggerEnter(Collider other) {
        if (exitPortal != null && (playerCanTeleport || other.gameObject.name != "XR Origin")) {
            other.gameObject.transform.position = exitPortal.transform.position + portalOffset;
            other.gameObject.transform.rotation = exitPortal.transform.rotation;

            Rigidbody otherRb = other.gameObject.GetComponent<Rigidbody>();
            if (otherRb != null) {
                otherRb.velocity = otherRb.velocity.magnitude * exitPortal.transform.forward;
            }

            audioSource.Play();
            exitPortal.GetComponent<AudioSource>().Play();
        }
    }
}
