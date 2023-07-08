using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombatController : MonoBehaviour
{
    private bool InCombat, IsPlayersTurn = false;
    public GameObject moveSelect, ItemSelect, confirmScreen;
    private int currentlySelectedItem = 1000;
    // Start is called before the first frame update
    void Update(){
        if(!InCombat) return;

        if(IsPlayersTurn){
            moveSelect.SetActive(true);
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
        ItemSelect.SetActive(true);
    }
    public void CloseItemSelect(){
        ItemSelect.SetActive(false);
    }
    public void ChooseItem(int itemNum){
        currentlySelectedItem = itemNum;
        Confirm();
    }
    //================================
    private void Confirm(){
        confirmScreen.SetActive(true);
    }
    public void Accept(int choice){
        confirmScreen.SetActive(false);
        ItemSelect.SetActive(false);
        moveSelect.SetActive(false);
        if(choice == 1){
            Attack1();
        }
        else if(choice == 2){
            Attack2();
        }
        else if(choice == 3){
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
    private void UseItem(){
        //useItem
        Debug.Log("Bruh3");
        IsPlayersTurn = false;
    }
}
