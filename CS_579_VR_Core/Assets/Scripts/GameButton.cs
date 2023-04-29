using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton : MonoBehaviour
{
    public AudioClip postitiveSound;
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
            bool didPressCorrectButton = gameManager.GetUserInput(transform.parent.gameObject);
            
            if (didPressCorrectButton) {
                audioSource.PlayOneShot(postitiveSound);
            }
            else {
                audioSource.PlayOneShot(negativeSound);
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
