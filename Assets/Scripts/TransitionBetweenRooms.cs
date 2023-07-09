using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionBetweenRooms : MonoBehaviour
{
    public Transform pos;
    public Animator RoomChangerAnimator;

    private void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Player"){
            Transition(col.gameObject);
        }
    }

    IEnumerator Transition(GameObject player){
        //make a 2 second animation to move rooms with
        RoomChangerAnimator.SetTrigger("MoveRooms");
        yield return new WaitForSeconds(2f);
        player.transform.position = pos.position;
    }
}
