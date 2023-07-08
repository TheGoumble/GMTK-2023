using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombatController : MonoBehaviour
{
    private bool InCombat, IsPlayersTurn = false;
    public Image moveSelect, ItemSelect, confirmScreen;
    private int currentlySelectedItem = 1000;
    // Start is called before the first frame update
    void Update(){
        if(!InCombat) return;

        if(IsPlayersTurn){
            moveSelect.enabled = true;
        }
        else{

        }
    }
    //================================
    
    public void Attack1Selected(){
        Confirm();
    }
    public void Attack2Selected(){
        Confirm();
    }

    //================================
    public void OpenItemSelect(){
        ItemSelect.enabled = true;
    }
    public void CloseItemSelect(){
        ItemSelect.enabled = false;
    }
    public void ChooseItem(int itemNum){
        currentlySelectedItem = itemNum;
        Confirm();
    }
    //================================
    private void Confirm(){
        confirmScreen.enabled = true;
    }
    public void Accept(int choice, int itemNum = 1000){
        confirmScreen.enabled = false;
        ItemSelect.enabled = false;
        moveSelect.enabled = false;
        if(choice == 1){
            Attack1();
        }
        else if(choice == 2){
            Attack2();
        }
        else if(choice == 3){
            UseItem(itemNum);
        }
    }
    public void Deny(){
        confirmScreen.enabled = false;
        currentlySelectedItem = 1000;
    }
    //================================


    private void Attack1(){
        //play attck1 animation
        IsPlayersTurn = false;
    }
    private void Attack2(){
        IsPlayersTurn = false;
    }
    private void UseItem(int ItemNum){
        //useItem
        IsPlayersTurn = false;
    }
}
