using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateRandomLetter : MonoBehaviour
{
    private string c = "";
    
    // Start is called before the first frame update
    void Awake(){
        string alphebet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        c = alphebet[Random.Range(0, alphebet.Length-1)].ToString();

        gameObject.GetComponent<TextMeshProUGUI>().text = c;
        Debug.Log(c);
    }
}
