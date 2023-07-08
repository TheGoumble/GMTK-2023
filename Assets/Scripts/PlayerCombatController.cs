using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombatController : MonoBehaviour
{
    private bool InCombat, IsPlayersTurn = false;
    public GameObject moveSelect, ItemSelect, confirmScreen, backUpPlayer;
    private int currentlySelectedItem = 1000;
    private int currentMove;
    // Start is called before the first frame update
    void Update(){
        if(!InCombat) return;

        if(IsPlayersTurn){
            moveSelect.SetActive(true);
        }
    }
    //================================
    
    public void Attack1Selected(){
        currentMove = 1;
        Confirm();
    }
    public void Attack2Selected(){
        currentMove = 2;
        Confirm();
    }
    public void CallBackup(){
        currentMove = 3;
        Confirm();
    }

    //================================
    public void OpenItemSelect(){
        ItemSelect.SetActive(true);
    }
    public void CloseItemSelect(){
        ItemSelect.SetActive(false);
    }
    public void ChooseItem(int itemNum){
        currentMove = 0;
        currentlySelectedItem = itemNum;
        Confirm();
    }
    //================================
    private void Confirm(){
        confirmScreen.SetActive(true);
    }
    public void Accept(){
        confirmScreen.SetActive(false);
        ItemSelect.SetActive(false);
        moveSelect.SetActive(false);
        if(currentMove == 1){
            Attack1();
        }
        else if(currentMove == 2){
            Attack2();
        }
        else if(currentMove == 3){
            TryCallBackup();
        }
        else if(currentMove == 4){
            UseItem();
        }
        else if(currentMove == 5){
            UseItem();
        }
        else if(currentMove == 6){
            UseItem();
        }
        else if(currentMove == 7){
            UseItem();
        }
    }
    public void Deny(){
        confirmScreen.SetActive(false);
        currentlySelectedItem = 1000;
    }
    //================================

    private void Attack1(){
        //play attck1 animation
        Debug.Log("Bruh");
        IsPlayersTurn = false;
    }
    private void Attack2(){
        Debug.Log("Bruh2");
        IsPlayersTurn = false;
    }

    private void TryCallBackup(){
        int backUpSucceeded = Random.Range(0, 2);
        if(backUpSucceeded == 1){
            BackUpSucceeded();
        }
        else if(backUpSucceeded == 0){
            BackUpFailed();
        }
    }
    private void UseItem(){
        //useItem
        Debug.Log("Bruh3");
        IsPlayersTurn = false;
    }

    private void BackUpSucceeded(){
        Debug.Log("Succeeded");
        GameObject backup = Instantiate(backUpPlayer);
        IsPlayersTurn = false;
    }
    private void BackUpFailed(){
        Debug.Log("Failed");
        IsPlayersTurn = false;
    }
}
