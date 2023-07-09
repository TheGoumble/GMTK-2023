using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartFishingMinigame : MonoBehaviour
{
    bool activeCoroutine;
    public string currentBiome; // grass, desert, snow, badlands
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
        GameManager.Instance.SetBiome(currentBiome);
        SceneManager.LoadScene("FishingMinigame");
        activeCoroutine = false;
        yield return null;
    }
}
