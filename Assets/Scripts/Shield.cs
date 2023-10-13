using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] int maxHealth = 10;
    [SerializeField] int curHealth;
    [SerializeField] float regenerationRate = 2f;
    [SerializeField] int regenerateAmount = 1;
    private void Start()
    {
        curHealth = maxHealth;
        InvokeRepeating("Regenerate", regenerationRate,regenerationRate);
    }
    void Regenerate()
    {
        if(curHealth < maxHealth)
            curHealth += regenerateAmount;

        EventManager.TakeDamage(curHealth / (float)maxHealth);

        if (curHealth > maxHealth)
            curHealth = maxHealth;

        Debug.Log("Regenrate");

    }
    public void TakeDamage(int dmg=1)
    {
        curHealth -=dmg;
        if(curHealth < 0)
        {
            curHealth = 0;
        }
        EventManager.TakeDamage(curHealth / (float)maxHealth);

        if (curHealth < 1) 
        {
            EventManager.PlayerDeath();

            GetComponent<Explosions>().BlowUp();

            Debug.Log("Dead");
        
        }
    }

}
