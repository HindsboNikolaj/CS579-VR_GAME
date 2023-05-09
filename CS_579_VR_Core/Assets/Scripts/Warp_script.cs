using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Warp_script : MonoBehaviour
{

    [SerializeField] public GameObject thing;
    [SerializeField] private InputActionReference missionButton;

    private CharacterController _characterController;
    
    private void Awake() => _characterController = GetComponent<CharacterController>();   

    private void OnEnable() => missionButton.action.performed += WarpStart;

    private void OnDisable() => missionButton.action.performed -= WarpStart;

    private void WarpStart(InputAction.CallbackContext obj){
        Destroy(thing);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
