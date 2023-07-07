using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueButtonTest : MonoBehaviour
{
    [SerializeField] DialogueController dialogueController;
    public void ReadNextLine()
    {
        dialogueController.ReadNextLine();
    }

    public void ReadGivenLine()
    {
        dialogueController.ReadGivenLine("Now you can say things out of a set rotation");
    }
}
