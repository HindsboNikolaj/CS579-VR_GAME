using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public GameObject exitPortal;

    private Vector3 portalOffset;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        portalOffset = exitPortal.transform.forward * 3;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {}

    void OnTriggerEnter(Collider other) {
        other.gameObject.transform.position = exitPortal.transform.position + portalOffset;
        other.gameObject.transform.rotation = exitPortal.transform.rotation;

        audioSource.Play();
        exitPortal.GetComponent<AudioSource>().Play();
    }
}
