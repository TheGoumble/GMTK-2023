using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DGCombatController : MonoBehaviour
{
    // Start is called before the first frame update
    private int currentLvl = 1;
    private int health, dmg;
    public bool dodging = false;
    public bool isDGTurn = false;
    public bool playerDodged = false;
    public Transform startMarker, endMarker;
    public GameObject QTE;
    public TextMeshProUGUI letter;
    public Animator GDAnimator;
    public PlayerCombatController playerCombatController;


    void Awake()
    {
        if(currentLvl == 1){
            health = 10;
            dmg = 1;
        }
    }

    void Update(){
        if(isDGTurn){
            int randomAttack = Random.Range(1, 3);
            if(randomAttack == 1){
                GDAnimator.SetBool("Attack1", true);
                dmg = 1;
            }
            else{
                GDAnimator.SetBool("Attack2", true);
                dmg = 3;
            }
                
            
            
        }
    }

    public void EndAnimations(){
        GDAnimator.SetBool("Attack1", false);
        GDAnimator.SetBool("Attack2", false);
        isDGTurn = false;
        playerCombatController.IsPlayersTurn = true;
    }

    public void EnablePlayerDodgeWindow(){
        QTE.SetActive(true);
        playerDodged = false;
        letter.GetComponent<GenerateRandomLetter>().GenerateLetter();
        
    }
    public void ClosePlayerDodgeWindow(){
        QTE.SetActive(false);
    }
    public void HitPlayer(int amount){
        if(!playerDodged)
            playerCombatController.gameObject.GetComponent<HealthController>().ChangeHealth(-dmg);
        else    
            Debug.Log("YOU DODGED");
        
    }

    public void FlipCharacter(){
        gameObject.GetComponent<SpriteRenderer>().flipX = !gameObject.GetComponent<SpriteRenderer>().flipX;
    }
}
