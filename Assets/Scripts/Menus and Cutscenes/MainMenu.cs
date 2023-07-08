using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject creditsMenu;
    [SerializeField] private TransitionScreen transitionScreen;
    public void PlayButton()
    {
        StartCoroutine(DoPlayGame());
        
    }
    public void CreditsButton()
    {
        creditsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void BackToMainMenuButton()
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }
    public void QuitButton()
    {
        Application.Quit();
    }

    IEnumerator DoPlayGame()
    {
        transitionScreen.FadeIn();
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene(1); // Load the opening cutscene
    }
}
