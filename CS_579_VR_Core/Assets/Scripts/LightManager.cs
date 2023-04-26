using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public Material litColor;
    public Material dimColor;
    public Material successColor;
    public Material failColor;

    private Renderer lightRenderer;
    private float flashLength; // Change in GameManager.cs

    // Start is called before the first frame update
    void Start()
    {
        lightRenderer = gameObject.GetComponent<Renderer>();
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
        lightRenderer.material = success ? successColor : failColor;
    }

    public void flash() {
        lightRenderer.material = litColor;
    }

    public void dim() {
        lightRenderer.material = dimColor;
    }
}
