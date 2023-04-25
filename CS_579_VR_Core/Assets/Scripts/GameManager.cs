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
    private float gameStartDelay = 1;
    private bool gameOver = true;
    
    public float flashLength = 1;
    private float timeBetweenFlashes = 0.5f;
    private float timeBetweenRounds = 1;

    private int numRounds = 3;
    private int firstSeqLength = 3;
    private string currSeq;
    private int currSeqIdx;
    
    private bool waitingForUserInput = false;
    private string userInput = "";

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.E)) {
            if (GetDistanceFromPlayer(startButton) < 2) {
                gameOver = false;
                StartCoroutine(beginGame());
            }
        }

        if (waitingForUserInput && Input.GetKeyDown(KeyCode.E)) {
            for (int i = 0; i < buttons.Length; i++) {
                if (GetDistanceFromPlayer(buttons[i]) < 2) {
                    userInput += i;

                    if (currSeq == userInput) {
                        waitingForUserInput = false;

                        if (currSeqIdx == numRounds - 1) {
                            ShowStatus(true);
                            gameOver = true;
                        }
                        else {
                            lights[i].GetComponent<LightManager>().flashLight();
                        }
                    }
                    else if (!currSeq.StartsWith(userInput)) {
                        ShowStatus(false);
                        waitingForUserInput = false;
                        gameOver = true;
                    }
                    else {
                        lights[i].GetComponent<LightManager>().flashLight();
                    }
                }
            }
        }
    }

    IEnumerator beginGame() {
        DimAllLights();
        yield return new WaitForSeconds(gameStartDelay);
        
        // Iterate through each round
        for (int i = 0; i < numRounds; i++) {
            currSeq = "";
            currSeqIdx = i;

            if (gameOver) {
                break;
            }

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
