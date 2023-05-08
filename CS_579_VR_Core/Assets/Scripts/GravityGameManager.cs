using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GravityGameManager : MonoBehaviour
{
    [SerializeField] GameObject[] sockets;
    [SerializeField] AudioClip successSound;
    [SerializeField] GameObject exitPortal;

    private AudioSource audioSource;

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
        bool allSocketsFull = true;

        foreach (GameObject socket in sockets) {
            XRSocketInteractor interactor = socket.GetComponent<XRSocketInteractor>();
            if (!interactor.hasSelection) {
                allSocketsFull = false;
            }
        }

        if (allSocketsFull) {
            audioSource.PlayOneShot(successSound);
            exitPortal.SetActive(true);
        }
    }
}
