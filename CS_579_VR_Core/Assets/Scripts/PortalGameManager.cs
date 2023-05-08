using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PortalGameManager : MonoBehaviour
{
    public GameObject socket;
    public GameObject exitPortal;
    public AudioClip successAudio;
    
    private AudioSource audioSource;
    private XRSocketInteractor interactor;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("GameAudio").GetComponent<AudioSource>();
        interactor = socket.GetComponent<XRSocketInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnSocketSelect() {
        audioSource.PlayOneShot(successAudio);
        exitPortal.SetActive(true);
    }
}
