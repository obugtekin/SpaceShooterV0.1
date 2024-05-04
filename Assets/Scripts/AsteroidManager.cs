using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] int NumberOfAsteroidsOfOnAxes= 10;
    [SerializeField] GameObject pickupPrefab;
    [SerializeField] Asteroid asteroidPrefab;
    [SerializeField] int gridSpacing =100;

    public List<Asteroid> asteroid = new List<Asteroid>();   
    void Start()
    {
       // PlaceAsteroids();
    }
    private void OnEnable()
    {
        EventManager.onStartGame += PlaceAsteroids;
        EventManager.onPlayerDeath += DestroyAsteroids;
        EventManager.onRespawnPickUp += PlacePickUp;
    }
    private void OnDisable()
    {
        EventManager.onStartGame -= PlaceAsteroids;
        EventManager.onPlayerDeath -= DestroyAsteroids;
        EventManager.onRespawnPickUp -= PlacePickUp;
    }
    void PlaceAsteroids()
    {
        for (int x = 0; x < NumberOfAsteroidsOfOnAxes; x++)
        {
            for(int y = 0; y < NumberOfAsteroidsOfOnAxes; y++)
            {
                for(int z = 0; z < NumberOfAsteroidsOfOnAxes; z++)
                {
                    InstantiateAsteroid(x, y, z);
                }
            }
            
        }
        PlacePickUp();
    }
    void DestroyAsteroids()
    {

        foreach(Asteroid ast in asteroid)
            ast.SelfDestruct();

        asteroid.Clear();
    }
    void InstantiateAsteroid(int x,int y, int z)
    {
        Asteroid temp= Instantiate(asteroidPrefab,
            new Vector3 (transform.position.x + (x * gridSpacing)+AsteroidOffset(),
                        transform.position.y+(y*gridSpacing)+AsteroidOffset(),
                        transform.position.z+(z*gridSpacing)+AsteroidOffset()), 
                        Quaternion.identity, 
                        transform) as Asteroid;

        temp.name="Asteroid:"+x+ "-"+y+"-"+ z;


        asteroid.Add(temp);
    }
    void PlacePickUp()
    {
        int rnd=Random.Range(0,asteroid.Count);

        Instantiate(pickupPrefab, asteroid[rnd].transform.position, Quaternion.identity);
        Debug.Log("Destroying" + asteroid[rnd].name);
       
        Destroy(asteroid[rnd].gameObject);
        asteroid.RemoveAt(rnd);
                 
    }

    float AsteroidOffset()
    {
        return Random.Range(-gridSpacing / 2f, gridSpacing / 2f);
    }
    void Update()
    {
        
    }
    
}
