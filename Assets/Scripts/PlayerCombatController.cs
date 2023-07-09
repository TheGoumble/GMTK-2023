using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCombatController : MonoBehaviour
{
    public bool InCombat, IsPlayersTurn = true;
    public GameObject PlayerTurnUI, moveSelect, ItemSelect, confirmScreen, backUpPlayer, QTE, slimeBallAttack;
    public Animator playerAnimator;
    private int currentlySelectedItem = 1000;
    private int currentMove;
    public TextMeshProUGUI letterText;
    private string currentLetterToPress = " ";
    private HealthController healthController;
    public DGCombatController goodGuyconmbatController;
    // Start is called before the first frame update

    void Start(){
        healthController = gameObject.GetComponent<HealthController>();
    }
    void Update(){
        if(!InCombat) return;
        if(IsPlayersTurn){
            PlayerTurnUI.SetActive(true);
            moveSelect.SetActive(true);
            if(QTE.activeInHierarchy){
                currentLetterToPress = letterText.text;
                if(Input.inputString.ToUpper() == currentLetterToPress){
                    Debug.Log("Bruhaef");
                }
            }
        }
        else{
            PlayerTurnUI.SetActive(false);

            if(QTE.activeInHierarchy){
                currentLetterToPress = letterText.text;
                if(Input.inputString.ToUpper() == currentLetterToPress){
                    goodGuyconmbatController.playerDodged = true;
                }
            }
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
        PlayerTurnUI.SetActive(false);
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
        playerAnimator.SetBool("Attack1", true);
    }

    private void Attack2(){
        playerAnimator.SetBool("Attack2", true);
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

    }

    private void BackUpSucceeded(){
        Debug.Log("Succeeded");
        GameObject backup = Instantiate(backUpPlayer);
    }
    private void BackUpFailed(){
        Debug.Log("Failed");
    }

    public void SetLetterActive(){
        QTE.SetActive(true);
        letterText.GetComponent<GenerateRandomLetter>().GenerateLetter();
    }

    public void SlimeBallAttack(){
        GameObject slimeBall = Instantiate(slimeBallAttack, gameObject.transform);
        slimeBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1f, 0f)*250, ForceMode2D.Force);
        StartCoroutine(DestroySlimeBall(slimeBall));
        gameObject.GetComponent<HealthController>().ChangeHealth(-2);
    }

    public void HitTimeOver(){
        QTE.SetActive(false);
    }

    public void EndAnimations(){
        IsPlayersTurn = false;
        goodGuyconmbatController.isDGTurn = true;
        playerAnimator.SetBool("Attack1", false);
        playerAnimator.SetBool("Attack2", false);
    }
    
    IEnumerator DestroySlimeBall(GameObject ball){
        yield return new WaitForSeconds(5f);
        Destroy(ball);
    }
}
