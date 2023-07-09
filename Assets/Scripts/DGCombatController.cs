using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DGCombatController : MonoBehaviour
{
    // Start is called before the first frame update
    private int currentLvl = 1;
    public int health, dmg;
    public bool dodging = false;
    public bool isDGTurn = false;
    public bool playerDodged = false;
    private bool madeMove = false;
    public Transform startMarker, endMarker;
    public GameObject QTE, slashAttack;
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
        if(isDGTurn && !madeMove){
            int randomAttack = Random.Range(1, 3);
            if(randomAttack == 1){
                GDAnimator.SetBool("Attack1", true);

                
                
            }
            else{
                GDAnimator.SetBool("Attack2", true);
                dmg = 1;
            }
            madeMove = true;
                
            
            
        }
    }
    public void SpawnSlash(){
        GameObject slash = Instantiate(slashAttack, gameObject.transform);
        slash.GetComponent<Rigidbody2D>().AddForce(new Vector2(1f, 0f)*250, ForceMode2D.Force);
        StartCoroutine(DestroySlash(slash));
    }
    IEnumerator DestroySlash(GameObject slash){
        yield return new WaitForSeconds(5f);
        Destroy(slash);
    }

    public void EndAnimations(){
        GDAnimator.SetBool("Attack1", false);
        GDAnimator.SetBool("Attack2", false);
        isDGTurn = false;
        madeMove = false;
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
    public void HitPlayer(){
        if(!playerDodged){
            Debug.Log(dmg);
            playerCombatController.gameObject.GetComponent<HealthController>().ChangeHealth(-dmg);
            playerCombatController.gameObject.GetComponent<Animator>().SetBool("GotHit", true);
            StartCoroutine(StopHitEffect());
        }
        else    
            Debug.Log("YOU DODGED");
        
    }

    public void FlipCharacter(){
        gameObject.GetComponent<SpriteRenderer>().flipX = !gameObject.GetComponent<SpriteRenderer>().flipX;
    }

    IEnumerator StopHitEffect(){
        yield return new WaitForSeconds(0.25f);
        playerCombatController.gameObject.GetComponent<Animator>().SetBool("GotHit", false);

    }
}
