using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
[RequireComponent(typeof(Light))]

public class Thruster : MonoBehaviour
{
    TrailRenderer tr;
    Light thrusterLight;
    private void Awake()
    {
        tr= GetComponent<TrailRenderer>();
        thrusterLight= GetComponent<Light>();
    }
   
    /*public void Activate(bool Activate =true)
    {
        if(Activate)
        {
            tr.enabled = true;
            thrusterLight.enabled = true;
        }
        else
        {
            tr.enabled = false;
            thrusterLight.enabled = false;
        }
    }*/

    public void Intensity(float inten)
    {
        thrusterLight.intensity = inten * 2f; 
    }
    // Start is called before the first frame update
    void Start()
    {
        //thrusterLight.enabled = false;
        //tr.enabled = false;
        thrusterLight.intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
