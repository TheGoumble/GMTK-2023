using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class OpeningDialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public Image frame1;
    public Image frame2;
    public Image frame3;
    public string[] lines;
    public float textSpeed;

    private int index;


    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            if(textComponent.text == lines[index]){
                NextLine();
            }else{
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue(){
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine(){
        foreach(char c in lines[index].ToCharArray()){
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {   
        if( index == 0 ){
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            frame1.enabled = false;
            frame2.enabled = true;
        }else if( index == 2 ){
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            frame2.enabled = false;
            frame3.enabled = true;
        }
        else if (index < lines.Length - 1){
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }else{
            gameObject.SetActive(false);
        }
    }
}
