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
    public Camera combatCamera, movementCamera;

    void Start(){
        ResetHealth();
        DGAnimator = gameObject.GetComponent<Animator>();
    }

    public void ResetHealth(){
        health = maxHealth;
        gameObject.GetComponent<Animator>().enabled = true;
    }

    public void ChangeHealth(int amount){
        health += amount;

        if(health <= 0){
            health = 0;
            //DGAnimator.SetTrigger("DeathEffect");
            gameObject.GetComponent<DGCombatController>().isDGTurn = false;
            gameObject.GetComponent<DGCombatController>().playerDodged = true;
            gameObject.GetComponent<DGCombatController>().EndAnimations();
            gameObject.GetComponent<DGCombatController>().dmg = 0;

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
        player.GetComponent<PlayerCombatController>().BattleCanvasUI.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        DeathParticles.Play();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Animator>().enabled = false;
        transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
        DGAnimator.SetBool("DeathEffect", false);
        transition.FadeIn();
        yield return new WaitForSeconds(6f);
        combatCamera.enabled = false;
        movementCamera.enabled = true;
        transition.FadeOut();
        yield return null;
    }
}

