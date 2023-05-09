using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Mission_Script : MonoBehaviour
{

    [SerializeField] private InputActionReference missionButton;

    private CharacterController _characterController;
    
    private void Awake() => _characterController = GetComponent<CharacterController>();   

    private void OnEnable() => missionButton.action.performed += MissionStart;

    private void OnDisable() => missionButton.action.performed -= MissionStart;

    private void MissionStart(InputAction.CallbackContext obj){
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
