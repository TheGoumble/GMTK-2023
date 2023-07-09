using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScroll : MonoBehaviour
{
    [SerializeField] private float creditsStep = 80f;
    [SerializeField] private float scrollTime = 200f;
    [SerializeField] GameObject escapeButton;
    void Start()
    {
        escapeButton.SetActive(false);
        StartCoroutine(DoCreditsScroll());
    }

    IEnumerator DoCreditsScroll()
    {
        yield return new WaitForSeconds(6f); // Wait for screen fade in
        escapeButton.SetActive(true);
        while(scrollTime > 0)
        {
            this.transform.position = new Vector3(transform.position.x, transform.position.y + creditsStep * Time.deltaTime, transform.position.z);
            scrollTime -= Time.deltaTime;
            yield return new WaitForSeconds(.001f);
        }
        
        yield return null;
    }

}
