using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject creditsMenu;
    [SerializeField] private TransitionScreen transitionScreen;
    [SerializeField] private Image pointer;
    public AudioSource audioSource;
    public AudioClip mainMenuClip;

    private void Start()
    {
        pointer.gameObject.SetActive(false);
    }
    public void PlayButton()
    {
        audioSource.clip = mainMenuClip;
        audioSource.Play();
        StartCoroutine(DoPlayGame());
        
    }
    public void CreditsButton()
    {
        audioSource.clip = mainMenuClip;
        audioSource.Play();
        creditsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void BackToMainMenuButton()
    {
        audioSource.clip = mainMenuClip;
        audioSource.Play();
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }

    public void ReturnToTitleScreenButton()
    {
        audioSource.clip = mainMenuClip;
        audioSource.Play();
        StartCoroutine(DoReturnToTitle());
    }
    
    public void QuitButton()
    {
        audioSource.clip = mainMenuClip;
        audioSource.Play();
        Application.Quit();
    }

    IEnumerator DoPlayGame()
    {
        transitionScreen.FadeIn();
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene(1); // Load the opening cutscene
    }

    IEnumerator DoReturnToTitle()
    {
        transitionScreen.FadeIn();
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene(0); // Load the title screen
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        pointer.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        pointer.gameObject.SetActive(false);
    }

    // TODO
    // Integrate game over scene into health system
    // CRT shader

}
