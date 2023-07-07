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
}
