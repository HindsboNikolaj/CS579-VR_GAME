using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton : MonoBehaviour
{
    public AudioClip postitiveSound;
    public AudioClip neutralSound;
    public AudioClip negativeSound;
    private AudioSource audioSource;

    private Animation buttonPress;
    private GameManager gameManager;
    private bool isInteractable = true;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        buttonPress = GetComponent<Animation>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other) {
        if (isInteractable && other.gameObject.CompareTag("Hand")) {
            PlayAnimation();
            int inputStatus = gameManager.GetUserInput(transform.parent.gameObject);

            switch (inputStatus) {
                case 0:
                    audioSource.PlayOneShot(neutralSound);
                    break;
                case 1:
                    audioSource.PlayOneShot(postitiveSound);
                    break;
                case 2:
                    audioSource.PlayOneShot(negativeSound);
                    break;
            }
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
