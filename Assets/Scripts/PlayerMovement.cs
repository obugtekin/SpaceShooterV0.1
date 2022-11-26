using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float turnSpeed = 60f;
    [SerializeField] float movementSpeed = 50f;
    [SerializeField] Thruster[] thruster;
    Transform myT;
    private void Awake()
    {
        myT = transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Turn();
        Thrust();
    }
    void Turn()
    {
        float yaw=turnSpeed*Time.deltaTime * Input.GetAxis("Horizontal");
        float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Pitch");
        float roll = turnSpeed * Time.deltaTime * Input.GetAxis("Roll");
        myT.Rotate(-pitch, yaw, -roll);
    }
    void Thrust()
    {
        if(Input.GetAxis("Vertical")>0)
        myT.position += myT.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");

    }
}
