using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{
    [SerializeField] float laserOffTime = .5f;
    [SerializeField] float maxDistance = 300f;
    bool canfire;

    LineRenderer lr;
    private void Awake()
    {
        lr= GetComponent<LineRenderer>();
    }
    public void FireLaser(Vector3 targetPosition)
    {
        if (canfire)
        {
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, targetPosition);
            lr.enabled = true;
            canfire= false; 
        }
        

        Invoke("TurnOffLaser", laserOffTime);
    }
    // Start is called before the first frame update
    void Start()
    {
        lr.enabled = false;
        

    }
    void TurnOffLaser()
    {
        lr.enabled = false;
        canfire = true;
    }
    // Update is called once per frame
    /*void Update()
    {
        FireLaser(transform.forward * maxDistance);
    }*/
}
