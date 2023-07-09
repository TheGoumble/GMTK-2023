using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class MapTrans : MonoBehaviour
{
    public Collider2D newBoarder;
    public Transform pos;
    public GameObject CinimaController;
    public TransitionScreen transition;
    private void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Player"){
            StartCoroutine(Transition(col.gameObject));
     
        }
    }

    IEnumerator Transition(GameObject player){
        //make a 2 second animation to move rooms with
        transition.FadeIn();
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(2f);
        
        transition.FadeOut();
        CinimaController.GetComponent<CinemachineConfiner>().m_BoundingShape2D = newBoarder;
        player.transform.position = pos.position;
        player.GetComponent<PlayerMovement>().enabled = true;
    }
}