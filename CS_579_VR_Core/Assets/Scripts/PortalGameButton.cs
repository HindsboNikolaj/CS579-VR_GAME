using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGameButton : MonoBehaviour
{
    public GameObject spawnObject;

    private AudioSource audioSource;
    private Animation buttonPress;
    private bool isInteractable = true;
    private Vector3 spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        buttonPress = GetComponent<Animation>();
        spawnPos = transform.position + new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if (isInteractable && other.gameObject.CompareTag("Hand")) {
            PlayAnimation();
            audioSource.Play();
            Instantiate(spawnObject, spawnPos, spawnObject.transform.rotation);
        }
    }

    void PlayAnimation() {
        isInteractable = false;
        buttonPress.Play();
        Invoke("SetInteractable", buttonPress.clip.length);
    }

    void SetInteractable() {
        isInteractable = true;
    }
}
