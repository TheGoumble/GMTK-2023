using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingMinigame : MonoBehaviour
{

    private Rigidbody2D rb;
    private bool jumpable;
    [SerializeField] GameObject fish_go;
    [SerializeField] GameObject slider_go;
    [SerializeField] GameObject splash_go;
    [SerializeField] GameObject grass_go;
    [SerializeField] GameObject desert_go;
    [SerializeField] GameObject snow_go;
    [SerializeField] GameObject badlands_go;
    [SerializeField] GameObject hp_go;

    private ParticleSystem splash;
    private Rigidbody2D fish_rb;
    private int tier;
    private ParticleSystem hp;

    public Sprite[] terribleFish;
    public Sprite[] badFish;
    public Sprite[] decentFish;
    public Sprite[] goodFish;
    public Sprite[] perfectFish;

    public string biome;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        jumpable = true;
        fish_rb = fish_go.gameObject.GetComponent<Rigidbody2D>();
        splash = splash_go.GetComponent<ParticleSystem>();
        biome = biome.ToLower();
        hp = hp_go.GetComponent<ParticleSystem>();

        if (biome == "grass")
        {
            grass_go.SetActive(true);
            desert_go.SetActive(false);
            snow_go.SetActive(false);
            badlands_go.SetActive(false);
        }
        else if (biome == "desert")
        {
            grass_go.SetActive(false);
            desert_go.SetActive(true);
            snow_go.SetActive(false);
            badlands_go.SetActive(false);
        }
        else if (biome == "snow")
        {
            grass_go.SetActive(false);
            desert_go.SetActive(false);
            snow_go.SetActive(true);
            badlands_go.SetActive(false);
        }
        else if (biome == "badlands")
        {
            grass_go.SetActive(false);
            desert_go.SetActive(false);
            snow_go.SetActive(false);
            badlands_go.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            ResetMinigame();
        }

        tier = slider_go.GetComponent<FishingSlider>().tier;

        if (Input.GetKeyDown(KeyCode.Space) && jumpable)
        {
            rb.AddForce(new Vector2(320,450));
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
            splash_go.transform.position = rb.transform.position;
            splash.Play();
            hp_go.transform.position = fish_go.transform.position;
            hp.Play();

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
    void ResetMinigame()
    {
        rb.position = new Vector2(-4.88f, 0.257f);
        fish_go.GetComponent<SpriteRenderer>().sprite = null;
        jumpable = true;
    }
}
