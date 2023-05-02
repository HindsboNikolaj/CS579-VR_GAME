using System.IO;
using System.Text.RegularExpressions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{

    private float minx=2f;
    private float maxx=3f;
    private float miny=2f;
    private float maxy=3f;
    private float minz=2f;
    private float maxz=3f;
    public float angle = 20*Mathf.PI/180;
    [SerializeField] public float positionDiff = 5;
    [SerializeField] public float timeFactor = 2;
    [SerializeField] public bool x_axis = true;
    [SerializeField] public bool positive_y = true;
    // Use this for initialization
    void Start () {
       
        minx=transform.position.x+positionDiff;
        maxx=transform.position.x+positionDiff;
        maxy=transform.position.y+positionDiff*Mathf.Sin(angle);
        miny=transform.position.y-positionDiff*Mathf.Sin(angle);
        maxz=transform.position.z+positionDiff*Mathf.Cos(angle); 
        minz=transform.position.z-positionDiff*Mathf.Cos(angle);
   
    }
   
    // Update is called once per frame
    void Update () {
       
        if(x_axis){
            if(positive_y){
                transform.position =new Vector3(
                    Mathf.PingPong(Time.time*timeFactor,positionDiff)+minx,
                    transform.position.y, transform.position.z);
            }
            else {
                transform.position =new Vector3(
                    -Mathf.PingPong(Time.time*timeFactor,positionDiff)+maxx,
                    transform.position.y, transform.position.z);
            }
            
        }
        else{
            if(positive_y){
                transform.position =new Vector3(transform.position.x, 
                (float)((Mathf.PingPong(Time.time*timeFactor,positionDiff)*Mathf.Sin(angle)+miny)), 
                (float)((Mathf.PingPong(Time.time*timeFactor,positionDiff)*Mathf.Cos(angle)+minz)));
            }
            else{
                transform.position =new Vector3(transform.position.x, 
                (float)((-Mathf.PingPong(Time.time*timeFactor,positionDiff)*Mathf.Sin(angle)+maxy)), 
                (float)((-Mathf.PingPong(Time.time*timeFactor,positionDiff)*Mathf.Cos(angle)+maxz)));
            }

        }
        
       
    }
}
