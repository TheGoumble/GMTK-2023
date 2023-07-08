using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private bool startSceneWithFade;   // If you want the scene to start w/a black screen that fades away
    [SerializeField] private float waitTime = 1f;    // Time it takes to go from one alpha value to the next
    [SerializeField] private int fadeIterations = 4;    // How many iterations/stages the fade effect should have

    private void Start()
    {
        if (startSceneWithFade)
        {
            canvasGroup.alpha = 1;
            StartCoroutine(DoFadeOut());
            
        }
        else
        {
            canvasGroup.alpha = 0;
        }
            
    }
    // Public methods ------------------------

    public void FadeIn() // Fades the black screen from alpha = 0 to alpha = 1
    {
        StopAllCoroutines();
        canvasGroup.alpha = 0;
        StartCoroutine(DoFadeIn());
    }

    public void FadeOut() // Fades the black screen from alpha = 1 to alpha = 0
    {
        StopAllCoroutines();
        canvasGroup.alpha = 1;
        StartCoroutine(DoFadeOut());
    }

    // Coroutines --------------------------------

    IEnumerator DoFadeIn()  // Fades the black screen from alpha = 0 to alpha = 1
    {
        for (int i = 0; i <= fadeIterations; i++)
        {
            canvasGroup.alpha = ((float)i / fadeIterations);
            yield return new WaitForSeconds(waitTime);
        }
        
    }

    IEnumerator DoFadeOut() // Fades the black screen from alpha = 1 to alpha = 0
    {
        for (int i = fadeIterations; i >= 0; i--)
        {
            canvasGroup.alpha = ((float)i / fadeIterations);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
