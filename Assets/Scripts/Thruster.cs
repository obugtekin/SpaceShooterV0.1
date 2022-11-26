using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class Thruster : MonoBehaviour
{
    TrailRenderer tr;
    private void Awake()
    {
            tr= GetComponent<TrailRenderer>();
    }
    public void Activate(bool Activate =true)
    {
        if(Activate)
        {
            tr.enabled = true;
        }
        else
        {
            tr.enabled = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
