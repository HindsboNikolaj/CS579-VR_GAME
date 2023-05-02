using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public Material litColor;
    public Material dimColor;
    public Material successColor;
    public Material failColor;

    private Renderer materialRenderer;
    private Light lightComponent;
    private AudioSource audioSource;
    private float flashLength; // Change in GameManager.cs

    // Start is called before the first frame update
    void Start()
    {
        materialRenderer = GetComponent<Renderer>();
        lightComponent = GetComponent<Light>();
        audioSource = GetComponent<AudioSource>();
        flashLength = GameObject.Find("GameManager").GetComponent<GameManager>().flashLength;
    }

    // Update is called once per frame
    void Update() {}

    public void flashLight() {
        Invoke("flash", 0);
        Invoke("dim", flashLength);
    }

    public void cancelFlash() {
        CancelInvoke();
    }

    public void showStatus(bool success) {
        materialRenderer.material = success ? successColor : failColor;
        lightComponent.enabled = true;
        lightComponent.color = materialRenderer.material.color;
    }

    public void flash() {
        audioSource.Play();
        materialRenderer.material = litColor;
        lightComponent.enabled = true;
        lightComponent.color = materialRenderer.material.color;
    }

    public void dim() {
        materialRenderer.material = dimColor;
        lightComponent.enabled = false;
    }
}
