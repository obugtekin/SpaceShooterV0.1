using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Laser))]
public class PlayerInput : MonoBehaviour
{

    
    
    [SerializeField] Laser[] laser;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    LineRenderer laserLine;
    // Update is called once per frame
    void Update()
    {
      
       
        if(Input.GetKeyDown(KeyCode.Space)) {

            foreach (Laser l in laser)
            {
                //Vector3 pos = transform.position + (transform.forward * l.Distance);
                laserLine=GetComponent<LineRenderer>();
                l.FireLaser();
            }
                
        
        }
    }
}
