using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] int NumberOfAsteroidsOfOnAxes= 10;
    [SerializeField] Asteroid asteroid;
    [SerializeField] int gridSpacing =100;
    // Start is called before the first frame update
    void Start()
    {
        PlaceAsteroids();
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
    }
    void InstantiateAsteroid(int x,int y, int z)
    {
        Instantiate(asteroid,
            new Vector3 (transform.position.x + (x * gridSpacing)+AsteroidOffset(),
                        transform.position.y+(y*gridSpacing)+AsteroidOffset(),
                        transform.position.z+(z*gridSpacing)+AsteroidOffset()), 
                        Quaternion.identity, 
                        transform);
    }
    float AsteroidOffset()
    {
        return Random.Range(-gridSpacing / 2f, gridSpacing / 2f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
}
