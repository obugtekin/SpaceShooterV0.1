using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosions : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] float laserHitModifier = 100f;
    public void IveBeenHit(Vector3 pos)
    {
        GameObject go = Instantiate(explosion, pos, Quaternion.identity, transform) as GameObject;

        Destroy(go, 6f);

    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
            IveBeenHit(contact.point);
    }
    public void AddForce(Vector3 hitPosition,Transform hitSource)
    {
        Debug.LogWarning("AdForce"+gameObject.name+"->"+ hitSource.name);
        if (rigidBody == null)
            return;
        Vector3 forceVector = (hitSource.position - hitPosition).normalized;
        Debug.Log(forceVector * laserHitModifier);
        rigidBody.AddForceAtPosition(forceVector*laserHitModifier, hitPosition,ForceMode.Impulse);
    }
    
}
