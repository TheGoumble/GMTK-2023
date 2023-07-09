using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishingMinigame : MonoBehaviour
{


    private bool jumpable;
    private bool direction;
    private bool moving;

    [SerializeField] GameObject fish_go;
    [SerializeField] GameObject shadow_go;
    [SerializeField] GameObject pointer;
    [SerializeField] GameObject slider_go;

    [SerializeField] GameObject splash_go;

    [SerializeField] GameObject grass_go;
    [SerializeField] GameObject desert_go;
    [SerializeField] GameObject snow_go;
    [SerializeField] GameObject badlands_go;

    //pp is Praise Particles, hp is Health Particles
    [SerializeField] GameObject pp_go;
    [SerializeField] GameObject text_go;
    [SerializeField] GameObject hp_go;
    [SerializeField] GameObject num_go;
    [SerializeField] GameObject plus_go;

    private Rigidbody2D fish_rb;
    private Rigidbody2D player_rb;

    private ParticleSystem hp;
    private ParticleSystem pp;
    private ParticleSystem splash;

    private Transform pointer_tf;

    private TMP_Text text;
    private TMP_Text number;
    private TMP_Text plus;

    public Sprite[] terribleFish;
    public Sprite[] badFish;
    public Sprite[] decentFish;
    public Sprite[] goodFish;
    public Sprite[] perfectFish;

    public int health_healed;
    public string biome;

    // Start is called before the first frame update
    void Start()
    {
        //Assigning values
        player_rb = GetComponent<Rigidbody2D>();
        fish_rb = fish_go.gameObject.GetComponent<Rigidbody2D>();

        jumpable = true;
        direction = true;
        moving = true;

        splash = splash_go.GetComponent<ParticleSystem>();
        pp = pp_go.GetComponent<ParticleSystem>();
        hp = hp_go.GetComponent<ParticleSystem>();

        pointer_tf = pointer.GetComponent<Transform>();

        text = text_go.GetComponent<TMP_Text>();
        number = num_go.GetComponent<TMP_Text>();
        plus = plus_go.GetComponent<TMP_Text>();

        biome = biome.ToLower();

        biome = GameManager.Instance.GetBiome();

        //Activating correct biome grid
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
    private void Update()
    {
        //Reset
        if (Input.GetKeyDown(KeyCode.D))
        {
            ResetMinigame();
        }

        //Jump
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && jumpable)
        {
            Jump();
        }
        //Random updates
        shadow_go.transform.position = new Vector2(player_rb.transform.position.x, -0.14f);
        
    }

    void FixedUpdate()
    {
        GetComponent<Animator>().SetFloat("yVelocity", player_rb.velocity.y);
        //If moving is true, allow the slider to move
        if (moving)
        {
            if (pointer_tf.position.x < 2.79 && direction)
            {
                pointer_tf.position = new Vector2(pointer_tf.position.x + 0.1f, pointer_tf.position.y);
            }
            else if (pointer_tf.position.x > -2.79 && !direction)
            {
                pointer_tf.position = new Vector2(pointer_tf.position.x - 0.1f, pointer_tf.position.y);
            }
            if (pointer_tf.position.x > 2.79 || pointer_tf.position.x < -2.79)
            {
                direction = !direction;
            }
        }
    }

    // When the slime hits the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If slime is not jumpable when it collides, display fish
        if (!jumpable)
        {
            fish_go.transform.position = gameObject.transform.position;
            fish_rb.AddForce(new Vector2(0f, 200f));
            fish_go.GetComponent<SpriteRenderer>().enabled = true;
            splash_go.transform.position = player_rb.transform.position;
            splash.Play();
            hp_go.transform.position = fish_go.transform.position;
            hp.Play();

            if (health_healed == 0)
            {
                fish_go.GetComponent <SpriteRenderer>().sprite = terribleFish[Random.Range(0,4)];
            }
            else if (health_healed == 1)
            {
                fish_go.GetComponent<SpriteRenderer>().sprite = badFish[Random.Range(0, 4)];
            }
            else if (health_healed == 2)
            {
                fish_go.GetComponent<SpriteRenderer>().sprite = decentFish[Random.Range(0, 7)];
            }
            else if (health_healed == 3)
            {
                fish_go.GetComponent<SpriteRenderer>().sprite = goodFish[Random.Range(0, 8)];
            }
            else if (health_healed == 5)
            {
                fish_go.GetComponent<SpriteRenderer>().sprite = perfectFish[Random.Range(0, 6)];
            }
        }
    }
    //Jump function
    void Jump()
    {
        //Force jump


        player_rb.AddForce(new Vector2(320, 450));

        jumpable = false;
        moving = false;

        //When the player jumps, take location of slider
        if ((pointer_tf.position.x >= -2.79 && pointer_tf.position.x < -1.895) || (pointer_tf.position.x <= 2.79 && pointer_tf.position.x > 1.895))
        {
            text.text = "TERRIBLE...";
            health_healed = 0;
            text.color = new Color(1f, 0.5f, 0.5f, 1f);
            number.color = new Color(1f, 0.5f, 0.5f, 1f);
        }
        else if ((pointer_tf.position.x >= -1.895 && pointer_tf.position.x < -1.227) || (pointer_tf.position.x <= 1.895 && pointer_tf.position.x > 1.227))
        {
            text.text = "BAD";
            health_healed = 1;
            text.color = new Color(0.9f, 0.2f, 0.1f, 1f);
            number.color = new Color(0.9f, 0.2f, 0.1f, 1f);
        }
        else if ((pointer_tf.position.x >= -1.227 && pointer_tf.position.x < -0.618) || (pointer_tf.position.x <= 1.227 && pointer_tf.position.x > 0.618))
        {
            text.text = "DECENT";
            health_healed = 2;
            text.color = new Color(1f, 0.64f, 0f, 1f);
            number.color = new Color(1f, 0.64f, 0f, 1f);
        }
        else if ((pointer_tf.position.x >= -0.618 && pointer_tf.position.x < -0.161) || (pointer_tf.position.x <= 0.618 && pointer_tf.position.x > 0.161))
        {
            text.text = "GOOD!";
            health_healed = 3;
            text.color = new Color(0.6f, 0.7f, 0.1f, 1f);
            number.color = new Color(0.6f, 0.7f, 0.1f, 1f);
        }
        else
        {
            text.text = "PERFECT!!";
            health_healed = 5;
            text.color = new Color(0f, 0.65f, 0.4f, 1f);
            number.color = new Color(0f, 0.65f, 0.4f, 1f);
        }
        pp.Play();
        number.text = health_healed.ToString();
        GameManager.Instance.SetHealthToHeal(health_healed);
        plus.color = number.color;
        jumpable = false;
        StartCoroutine(ReturnToMain());
    }

    //Resets the minigame, mainly for debugging
    void ResetMinigame()
    {
        player_rb.position = new Vector2(-4.88f, 0.257f);
        fish_go.GetComponent<SpriteRenderer>().sprite = null;
        jumpable = true;
        moving = true;
    }

    IEnumerator ReturnToMain()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Main");
        yield return null;
    }
}
