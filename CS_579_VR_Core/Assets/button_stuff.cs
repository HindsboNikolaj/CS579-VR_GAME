using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_stuff : MonoBehaviour
{
    public void on_begin(){
        SceneManager.LoadScene("SampleScene");
    }
    public void destroy_canvas(GameObject thing){
        Destroy(thing);
    }
}