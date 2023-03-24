using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;

    private int MAX_HEALTH = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetHealth(int maxHealth, int health){
        this.MAX_HEALTH = maxHealth;
        this.health = health;
    }

    


    public void Damage(int amount){

        if(amount < 0){
            throw new System.ArgumentException("Damage amount must be positive");
        }

        health -= amount;
        if(health <= 0){
            Destroy(gameObject);
        }
    }

    public void Heal(int amount){
        if(amount < 0){
            throw new System.ArgumentException("Health amount must be positive");
        }

        health += amount;
        if(health > MAX_HEALTH){
            health = MAX_HEALTH;
        }
    }
}
