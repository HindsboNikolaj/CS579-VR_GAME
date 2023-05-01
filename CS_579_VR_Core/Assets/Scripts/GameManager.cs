using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] lights;
    public GameObject[] buttons;
    public GameObject startButton;
    public GameObject shipPortal;

    private GameObject player;
    private float gameStartDelay = 2;
    private bool gameOver = true;
    private bool gameCompleted = false;
    
    public float flashLength = 1;
    private float timeBetweenFlashes = 0.5f;
    private float timeBetweenRounds = 1;

    private int numRounds = 3;
    private int firstSeqLength = 1;
    private string currSeq;
    private int currSeqIdx;
    
    private bool waitingForUserInput = false;
    private string userInput = "";
    private float buttonTriggerDistance = 5;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("XR Origin");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && !gameCompleted && Input.GetButtonDown("XRI_Right_SecondaryButton")) {
            if (GetDistanceFromPlayer(startButton) < buttonTriggerDistance) {
                gameOver = false;
                StartCoroutine(beginGame());
            }
        }
    }

    public void StartButtonPressed() {
        if (gameOver && !gameCompleted) {
            gameOver = false;
            StartCoroutine(beginGame());
        }
    }

    IEnumerator beginGame() {
        DimAllLights();
        yield return new WaitForSeconds(gameStartDelay);
        
        // Iterate through each round
        for (int i = 0; i < numRounds; i++) {
            if (gameOver) {
                break;
            }
            
            currSeq = "";
            currSeqIdx = i;

            // Flash randomized light sequence
            for (int j = 0; j < firstSeqLength + currSeqIdx; j++) {
                int lightIdx = Random.Range(0, lights.Length);
                currSeq += lightIdx;
                lights[lightIdx].GetComponent<LightManager>().flashLight();
                yield return new WaitForSeconds(flashLength);

                // Wait for time between flashes if this flash isn't the last in the sequence
                if (j != firstSeqLength + currSeqIdx - 1) {
                    yield return new WaitForSeconds(timeBetweenFlashes);
                }
            }
            
            userInput = "";
            waitingForUserInput = true;
            while(waitingForUserInput) yield return null;

            yield return new WaitForSeconds(flashLength + timeBetweenRounds);
        }
    }

    float GetDistanceFromPlayer(GameObject obj) {
        return (player.transform.position - obj.transform.position).magnitude;
    }

    // Returns 0 if game isn't finished, 1 if game is successfuly completed, and 2 if game is failed
    public int GetUserInput(GameObject button) {
        if (waitingForUserInput) {
            for (int i = 0; i < buttons.Length; i++) {
                if (buttons[i] == button) {
                    userInput += i;

                    foreach(GameObject light in lights) {
                        light.GetComponent<LightManager>().cancelFlash();
                    }

                    if (currSeq == userInput) {
                        waitingForUserInput = false;

                        if (currSeqIdx == numRounds - 1) {
                            ShowStatus(true);
                            gameOver = true;
                            gameCompleted = true;
                            return 1;
                        }
                        else {
                            lights[i].GetComponent<LightManager>().flashLight();
                        }
                    }
                    else if (!currSeq.StartsWith(userInput)) {
                        ShowStatus(false);
                        waitingForUserInput = false;
                        gameOver = true;
                        return 2;
                    }
                    else {
                        lights[i].GetComponent<LightManager>().flashLight();
                    }
                }
            }
        }
        return 0;
    }

    void ShowStatus(bool success) {
        foreach (GameObject light in lights) {
            light.GetComponent<LightManager>().showStatus(success);
        }

        if (success) {
            shipPortal.SetActive(true);
        }
    }

    void DimAllLights() {
        foreach (GameObject light in lights) {
            light.GetComponent<LightManager>().dim();
        }
    }
}
