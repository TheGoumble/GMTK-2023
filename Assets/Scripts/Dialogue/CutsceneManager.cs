using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Goes on a gameObject containing the TMP asset and the text box

public class CutsceneManager : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float textSpeed;
    [SerializeField] private TextAsset linesTXT;       // .txt file for lines
    [SerializeField] private Image[] frames;            // Frames corresponding to linesd
    [SerializeField] private Vector3[] textPositions;   // Where the textbox will be on the screen for each frame
    [SerializeField] private Image nextIndicator;       // The little hand that tells you to move on
    private string[] lines;

    private int currentLine;


    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        getFileContents();
        StartDialogue();
        nextIndicator.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            if(textComponent.text == lines[currentLine]){   // If the text is finished, advance to next line
                NextLine();
            }else{                                          // If the text isn't finished, finish it
                StopAllCoroutines();
                textComponent.text = lines[currentLine];
                nextIndicator.gameObject.SetActive(true);
            }
        }
    }

    // Private methods ----------------------------------------
    private void StartDialogue()
    {
        this.transform.localPosition = textPositions[currentLine];
        currentLine = 0;
        StartCoroutine(TypeLine());
    }

    private void NextLine()
    {
        nextIndicator.gameObject.SetActive(false);
        if (currentLine < lines.Length - 1)
        {
            currentLine++;
            this.transform.localPosition = textPositions[currentLine];
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            if(frames[currentLine - 1] != frames[currentLine])
            {
                frames[currentLine - 1].enabled = false;
                frames[currentLine].enabled = true;
            }
            
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void getFileContents()  // Splits up the text file into usable lines
    {
        lines = linesTXT.text.Split('\n');
    }

    // Coroutines ----------------------------------------
    IEnumerator TypeLine()
    {
        foreach (char c in lines[currentLine].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        nextIndicator.gameObject.SetActive(true);
    }


    // TODO
    // Make it so that you can add a scene to transition to
    // Add a fade-to-black transition to whatever comes next (separate file/setup so it can be reused)
    // Make the main menu, why not
}
