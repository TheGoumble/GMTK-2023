using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthController : MonoBehaviour
{
    public int health, maxHealth = 10;
    public Slider healthBar;
    public TextMeshProUGUI healthText, maxHealthText;
    void Start(){
        SetHealth();
    }

    public void SetHealth(){
        healthBar.maxValue = maxHealth;
        maxHealthText.text = maxHealth.ToString();
    }

    public void ChangeHealth(int amount){
        health += amount;

        if(health <= 0){
            health = 0;
            Death();
        }
        else if(health > maxHealth){
            health = maxHealth;
        }
        healthBar.value = health;
        healthText.text = health.ToString();
    }
    public void Death(){

    }
}
