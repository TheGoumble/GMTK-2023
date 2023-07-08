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

    private void Start()
    {
        pointer.gameObject.SetActive(false);
    }
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        pointer.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        pointer.gameObject.SetActive(false);
    }

}
