using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weight : MonoBehaviour
{
    public float weight = 70;

    private TextMeshPro text;

    // Start is called before the first frame update
    void Start()
    {
        text = transform.Find("Text").GetComponent<TextMeshPro>();
        text.SetText(weight.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
