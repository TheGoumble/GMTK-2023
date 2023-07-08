using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatDialogueController : MonoBehaviour
{
    public DialogueController test;
    public void Start(){
        test.ReadGivenLine("HEHEHEHAW", true);
    }
}
