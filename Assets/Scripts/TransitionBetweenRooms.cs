using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;
using UnityEngine.SceneManagement;

public class TransitionBetweenRooms : MonoBehaviour
{
    public GameObject combatPlayer;
    public Camera battleCam, movementCam;
    public TransitionScreen transition;

    public GameObject room;
    public GameObject GoodDoer;





    private void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Player"){
            room.SetActive(true);
            StartCoroutine(Transition(col.gameObject));
            col.gameObject.GetComponent<PlayerMovement>().enabled = false;
            col.gameObject.SetActive(false);
            

        }
    }

    IEnumerator Transition(GameObject player){
        //make a 2 second animation to move rooms with
        
        transition.FadeIn();
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(2f);
       
        battleCam.enabled = true;
        movementCam.enabled = false;
            
        
        transition.FadeOut();
        player.GetComponent<PlayerMovement>().enabled = true;
        player.SetActive(true);
        
        combatPlayer.GetComponent<PlayerCombatController>().InCombat = true;
        Destroy(gameObject);
        GoodDoer.GetComponent<DGHealth>().ResetHealth();
    }
    private void Update() {
        if(room.name == "Map3Arena" && GoodDoer.GetComponent<DGHealth>().health <= 0 && room.activeInHierarchy){
            SceneManager.LoadScene(4);
        }
    }
}