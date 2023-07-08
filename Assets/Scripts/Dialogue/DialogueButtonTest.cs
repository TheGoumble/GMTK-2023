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
        dialogueController.ReadGivenLine("Test line for out of order inserts", true);
    }
}
