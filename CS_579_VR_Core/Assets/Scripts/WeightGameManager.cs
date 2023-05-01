using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WeightGameManager : MonoBehaviour
{
    public GameObject[] sockets;
    public GameObject portal;
    public AudioClip successAudio;

    private AudioSource audioSource;
    private float targetWeight = 341;
    private float currWeight = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("GameAudio").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSocketSelect() {
        currWeight = 0;
        foreach (GameObject socket in sockets) {
            XRSocketInteractor interactor = socket.GetComponent<XRSocketInteractor>();
            if (interactor.hasSelection) {
                // Extract weight from object attached to socket
                currWeight += interactor.GetOldestInteractableSelected().transform.gameObject.GetComponent<Weight>().weight;
            }
        }

        if (currWeight == targetWeight) {
            portal.SetActive(true);
            audioSource.PlayOneShot(successAudio);
        }
    }
}