using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        this.currentHealth = this.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.currentHealth <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void DamageCharacter(int damage)
    {
        this.currentHealth -= damage;
    }
    public void UpdateMaxHealth(int newMaxHelth)
    {
        this.maxHealth = newMaxHelth;
        this.currentHealth = this.maxHealth;
    }
}
