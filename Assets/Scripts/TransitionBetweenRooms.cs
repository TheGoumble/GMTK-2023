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
    public GameObject CinimaController;
    public bool sendToBattle;
    public Camera battleCam, movementCam;

    private void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Player"){
            StartCoroutine(Transition(col.gameObject));
            if(sendToBattle){
                battleCam.enabled = true;
                movementCam.enabled = false;
                col.gameObject.GetComponent<PlayerMovement>().enabled = false;
            }
            
        }
    }

    IEnumerator Transition(GameObject player){
        //make a 2 second animation to move rooms with
        // RoomChangerAnimator.SetTrigger("MoveRooms");
    
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(2f);
        CinimaController.GetComponent<CinemachineConfiner>().m_BoundingShape2D = newBoarder;
        player.transform.position = pos.position;
        if(!sendToBattle)
            player.GetComponent<PlayerMovement>().enabled = true;
    }
}