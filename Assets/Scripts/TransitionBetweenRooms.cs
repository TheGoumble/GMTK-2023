using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionBetweenRooms : MonoBehaviour
{
    public Transform pos;

    private void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Player"){
            col.gameObject.transform.position = pos.position;
            
        }
    }
}
