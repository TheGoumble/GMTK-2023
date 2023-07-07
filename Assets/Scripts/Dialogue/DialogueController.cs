using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    [Header("Text Boxes + Setup [Do Not Change]")]
    [SerializeField] private TextMeshPro speakerNameText;   // The TMPro assets holding the text
    [SerializeField] private TextMeshPro speakerWords;
    [SerializeField] private SpriteRenderer mainBox;        // Main box (for sprite purposes)

    [Header("Speaker Details")]
    [SerializeField] private string speakerName;    // Name of the speaker
    [SerializeField] private bool isFacingRight;    // Whether the speaker is facing left or right
    [Header("Textbox Details")]
    [SerializeField] private float xOffset = 1f;    // Offset of text bubble from parent
    [SerializeField] private float yOffset = 1f;
    [SerializeField] private float waitToReadTime = 3f; // How long the textbox should remain onscreen after it'sdone reading
    [Header("Dialogue File")]
    [SerializeField] private TextAsset linesTXT;       // .txt file for lines

    private Transform parent;                       // Transform of the parent for positioning
    private string[] lines;                         // The actual lines in a usable form
    private int currentLine = 0;

    private void Start()
    {
        this.transform.position = Vector3.zero;
        parent = GetComponentInParent<Transform>();
        if(isFacingRight)
            this.transform.localPosition = new Vector3(parent.position.x + xOffset, parent.position.y + yOffset, parent.position.z);
        else
        {
            this.transform.localPosition = new Vector3(parent.position.x - xOffset, parent.position.y + yOffset, parent.position.z);
            mainBox.flipX = true;
        }
            
        speakerNameText.text = speakerName;
        getFileContents();
        this.gameObject.SetActive(false);
    }

    // Public methods --------------------------------------------------------
    public void ReadNextLine()  // Call this to read the next line of dialogue in the text doc
    {
        StopAllCoroutines();
        speakerWords.text = "";                 // Clear the bubble so it can be read out
        // TODO: Add something here for a determination of the size of the text bubble
        this.gameObject.SetActive(true);        // Show the dialogue bubble
        StartCoroutine(DoReadLine(lines[currentLine]));
        currentLine++;      // Increment the line we're on so we read the next line next time
        if (currentLine == lines.Length)
        {
            currentLine = 0;
        }
    }

    public void ReadGivenLine(string givenLine) // For if you want a character to say a line that's out of sequence
    {
        StopAllCoroutines();
        speakerWords.text = "";                 // Clear the bubble so it can be read out
        // TODO: Add something here for a determination of the size of the text bubble
        this.gameObject.SetActive(true);        // Show the dialogue bubble
        StartCoroutine(DoReadLine(givenLine));
    }

    // Private methods --------------------------------------------------------
    private void getFileContents()  // Splits up the text file into usable lines
    {
        lines = linesTXT.text.Split('\n');
    }

    private void setPositionAndScale(string line)  // Sets position and scale of the textbox based on how long the message is
    {
        this.transform.position = Vector3.zero;
    }

    // Coroutines --------------------------------------------------------------
    
    IEnumerator DoReadLine(string line)
    {
        var numCharsRevealed = 0;               // Read out the text letter by letter
        while (numCharsRevealed < line.Length)
        {
            ++numCharsRevealed;
            speakerWords.text = line.Substring(0, numCharsRevealed);
            yield return new WaitForSeconds(0.03f);
        }
        yield return new WaitForSeconds(waitToReadTime);     // Wait so the player can read it
        this.gameObject.SetActive(false);        // Hide the dialogue bubble


        yield return null;
    }

    // TODO
    // - If a message is a certain length, the text box should be bigger or smaller
}
