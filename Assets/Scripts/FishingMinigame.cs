using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingMinigame : MonoBehaviour
{

    private Rigidbody2D rb;
    private bool jumpable;
    [SerializeField] GameObject fish_go;
    [SerializeField] GameObject slider_go;
    private Rigidbody2D fish_rb;
    private int tier;

    public Sprite[] terribleFish;
    public Sprite[] badFish;
    public Sprite[] decentFish;
    public Sprite[] goodFish;
    public Sprite[] perfectFish;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        jumpable = true;
        fish_rb = fish_go.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        tier = slider_go.GetComponent<FishingSlider>().tier;

        if (Input.GetKeyDown(KeyCode.Space) && jumpable)
        {
            rb.AddForce(new Vector2(250,250));
            jumpable = false;
        }
    }

    // When the slime hits the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!jumpable)
        {
            fish_go.transform.position = gameObject.transform.position;
            fish_rb.AddForce(new Vector2(0f, 200f));
            fish_go.GetComponent<SpriteRenderer>().enabled = true;

            if (tier == 1)
            {
                fish_go.GetComponent <SpriteRenderer>().sprite = terribleFish[Random.Range(0,4)];
            }
            else if (tier == 2)
            {
                fish_go.GetComponent<SpriteRenderer>().sprite = badFish[Random.Range(0, 4)];
            }
            else if (tier == 3)
            {
                fish_go.GetComponent<SpriteRenderer>().sprite = decentFish[Random.Range(0, 7)];
            }
            else if (tier == 4)
            {
                fish_go.GetComponent<SpriteRenderer>().sprite = goodFish[Random.Range(0, 8)];
            }
            else if (tier == 5)
            {
                fish_go.GetComponent<SpriteRenderer>().sprite = perfectFish[Random.Range(0, 6)];
            }
        }
    }
}
