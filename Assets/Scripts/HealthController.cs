using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class HealthController : MonoBehaviour
{
    public int health, maxHealth = 10;
    public Slider healthBar;
    public TextMeshProUGUI healthText, maxHealthText;
    public TransitionScreen transition;
    private ParticleSystem DeathParticles;
    private Animator DeathAnimation;
    void Start(){
        SetHealth();
        DeathParticles = transform.GetChild(0).GetComponent<ParticleSystem>();
        DeathAnimation = GetComponent<Animator>();
        if(GameManager.Instance.GetHealthToHeal() > 0)
        {
            ChangeHealth(GameManager.Instance.GetHealthToHeal());
            GameManager.Instance.SetHealthToHeal(0);
        }
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
        StartCoroutine(DoDeath());
    }

    IEnumerator DoDeath()
    {
        // You can add whatever animations or control freezes or things you want before this,
        // but it will always end with this scene change

        DeathAnimation.SetTrigger("Died");
        yield return new WaitForSeconds(2.5f);
        DeathParticles.Play();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
        transition.FadeIn();
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene("99_GameOver");

        yield return null;
    }
}
