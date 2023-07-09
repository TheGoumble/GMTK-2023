using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    //private CircleCollider2D interactionRadius;
    [SerializeField] private DialogueController dialogue;
    bool activeCoroutine;
    private void Start()
    {
        activeCoroutine = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!activeCoroutine)
        {
            StartCoroutine(DoInteraction());
        }
    }

    IEnumerator DoInteraction()
    {
        activeCoroutine = true;
        for(int i = 0; i < dialogue.lines.Length; i++)
        {
            dialogue.ReadNextLine();
            yield return new WaitForSeconds(dialogue.waitToReadTime + 1f);
        }
        activeCoroutine = false;

    }
}
