using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class TransitionBetweenRooms : MonoBehaviour
{
    public Collider2D newBoarder;
    public Transform pos;
    public Animator RoomChangerAnimator;
    public GameObject CinimaController, combatPlayer;
    public bool sendToBattle;
    public Camera battleCam, movementCam;
    public TransitionScreen transition;

    private void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Player"){
            StartCoroutine(Transition(col.gameObject));
            if(sendToBattle){
                col.gameObject.GetComponent<PlayerMovement>().enabled = false;
                col.gameObject.SetActive(false);
            }

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
        CinimaController.GetComponent<CinemachineConfiner>().m_BoundingShape2D = newBoarder;
        player.transform.position = pos.position;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.SetActive(true);
        combatPlayer.GetComponent<PlayerCombatController>().InCombat = true;
        yield return null;
    }
}