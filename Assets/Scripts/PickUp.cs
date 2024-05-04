using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[DisallowMultipleComponent]
// [RequireComponent(typeof(CapsuleCollider))]
public class PickUp : MonoBehaviour
{
  //  [SerializeField] GameObject pickupPrefab;
  //  [SerializeField] PickUp pickuprefab;
    [SerializeField] float rotationOffset = 100f;
    bool gotHit=false;
    Transform myT;
    Vector3 randomRotation;
    static int points = 100;
 //   public static float destructionDelay = 1.0f;

   // public List<PickUp> pickup = new List<PickUp>();


    /*private void OnEnable()
    {
        EventManager.onPlayerDeath += DestroyPickUp;

    }
    private void OnDisable()
    {
        EventManager.onPlayerDeath -= DestroyPickUp;

    }*/

    private void Awake()
    {
        myT = transform;
    }  
    private void Start()
    {    
        randomRotation.x = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.y = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.z = Random.Range(-rotationOffset, rotationOffset);
    }
    private void Update()
    {
        myT.Rotate(randomRotation * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.name);
        if (col.transform.CompareTag("Player"))
        {
            if (!gotHit)
            {             
                PickupHit();
            }
        }
    }
    public void PickupHit()
    {
        if (!gotHit)
        {
            gotHit = true;
            Debug.Log("Player hit us");
            EventManager.ScorePoints(points);
            EventManager.ReSpawnPickUp();
            Destroy(gameObject);
        }      
    }
   /* void DestroyPickUp()
    {

        foreach (PickUp ast in pickup)
            ast.SelfDestruct();

        pickup.Clear();
    }*/
   /* public void SelfDestruct()
    {

        float timer = Random.Range(0, destructionDelay);

        Invoke("GoBoom", timer);
    }*/
}
