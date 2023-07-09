using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DGHealth : MonoBehaviour
{
    private Animator DGAnimator;
    public int health = 10;
    public int maxHealth = 10;
    public ParticleSystem DeathParticles;
    public GameObject player;
    public Transform postFightPosition;
    public TransitionScreen transition;
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
            //DGAnimator.SetTrigger("DeathEffect");
            gameObject.GetComponent<DGCombatController>().EndAnimations();
            player.GetComponent<PlayerCombatController>().InCombat = false;
            StartCoroutine(DoDeath());
        }
        else if(health > maxHealth){
            health = maxHealth;
        }
    }
    IEnumerator DoDeath()
    {
        // You can add whatever animations or control freezes or things you want before this,
        // but it will always end with this scene change

        DGAnimator.SetBool("DeathEffect", true);
        yield return new WaitForSeconds(2.5f);
        DeathParticles.Play();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
        DGAnimator.SetBool("DeathEffect", false);
        transition.FadeIn();
        yield return new WaitForSeconds(6f);
        transition.FadeOut();
        player.transform.position = postFightPosition.position;

        yield return null;
    }
}

