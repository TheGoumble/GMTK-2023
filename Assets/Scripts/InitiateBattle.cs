using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InitiateBattle : MonoBehaviour
{
    public Image BeginBattleImage;
    public float StartBattleSceneTimer = 0.4f;
    // Start is called before the first frame update
    private void FixedUpdate(){
        GetComponent<Rigidbody2D>().velocity += Vector2.right / 5;
    }
    private void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Player"){
            StartCoroutine(StartBattle());
        }
    }
    IEnumerator StartBattle(){
        BeginBattleImage.GetComponent<Animator>().SetBool("BeginBatleIntro", true);
        yield return new WaitForSeconds(StartBattleSceneTimer);
        SceneManager.LoadScene(1);
    }
}
