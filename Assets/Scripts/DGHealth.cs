using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DGHealth : MonoBehaviour
{
    private Animator DGAnimator;
    public int health = 10;
    public int maxHealth = 10;
    void Start(){
        ResetHealth();
        DGAnimator = gameObject.GetComponent<Animator>();
    }

    public void ResetHealth(){
        health = maxHealth;
    }

    public void ChangeHealth(int amount){
        health += amount;

        if(health <= 0){
            health = 0;
            DGAnimator.SetTrigger("DeathEffect");
        }
        else if(health > maxHealth){
            health = maxHealth;
        }
    }
    public void Death(){
        
    }
}
