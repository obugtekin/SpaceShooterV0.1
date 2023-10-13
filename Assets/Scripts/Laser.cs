using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(Light))]
public class Laser : MonoBehaviour
{
    [SerializeField] float laserOffTime = .5f;
    [SerializeField] float maxDistance = 300f;
    [SerializeField] float fireDelay = 2f;
    bool canfire;
    Light laserLight;

    LineRenderer lr;
    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        laserLight = GetComponent<Light>();
    }
    /* void Update()
     {
         FireLaser(transform.forward * maxDistance);
     }*/
    void Start()
    {
        lr.enabled = false;
        canfire = true;
        laserLight.enabled = false;

    }
  /*  private void Update()
    {
        Debug.DrawRay(transform.position, transform.position + (transform.forward) * maxDistance, Color.yellow);
    }*/
    Vector3 CastRay()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward) * maxDistance;

        if (Physics.Raycast(transform.position, fwd, out hit))
        {
            Debug.Log("WE hit" + hit.transform.name);

            SpawnExplosion(hit.point, hit.transform);

            if (hit.transform.CompareTag("PickUp"))
                hit.transform.GetComponent<PickUp>().PickupHit();

            return hit.point;

        }
        Debug.Log("Miss ");
        return transform.position + (transform.forward * maxDistance);
    }
    void SpawnExplosion(Vector3 hitPosition, Transform target)
    {
        Explosions temp = target.transform.GetComponent<Explosions>();
        if (temp != null)
        {
            temp.AddForce(hitPosition, transform);
        }
    }
    public void FireLaser()
    {
        Vector3 pos=CastRay(); 
        FireLaser(pos);

      // FireLaser(CastRay());   
    }
    public void FireLaser(Vector3 targetPosition,Transform target=null)
    {
        if (canfire)
        {
            if(target != null)
            {
                SpawnExplosion(targetPosition, target);

            }
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, targetPosition);
            lr.enabled = true;
            laserLight.enabled = true;
            canfire = false;
            Invoke("TurnOffLaser", laserOffTime);
            Invoke("CanFire", fireDelay);
        }

    }
    void TurnOffLaser()
    {
        lr.enabled = false;
        laserLight.enabled = false;
    }
    public float Distance
    {
        get { return maxDistance; }
    }
    void CanFire()
    {
        canfire = true;
    }
}

