using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   

    Rigidbody2D rb;

    float walkSpeed = 4f;
    float speedLimiter = 0.7f;
    float inputHorizontal;
    float inputVertical;

    [SerializeField] Transform BadlandsSpawn;
    [SerializeField] Transform IceSpawn;
    [SerializeField] Transform DesertSpawn;
    [SerializeField] Transform GrassSpawn;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        if(GameManager.Instance.GetBiome() != null && GameManager.Instance.GetBiome() != "")
        {
            if(GameManager.Instance.GetBiome() == "badlands")
            {
                transform.position = BadlandsSpawn.position;
            }
            else if (GameManager.Instance.GetBiome() == "grass")
            {
                transform.position = GrassSpawn.position;
            }
            if (GameManager.Instance.GetBiome() == "ice")
            {
                transform.position = IceSpawn.position;
            }
            if (GameManager.Instance.GetBiome() == "desert")
            {
                transform.position = DesertSpawn.position;
            }
        }
    }
    
    void Update()
    {
        //handle the input
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

    }

    void FixedUpdate()
    {
        //does actual movement
        if (inputHorizontal != 0 || inputVertical != 0)
        {
            if (inputHorizontal != 0 && inputVertical != 0)
            {
                inputHorizontal *= speedLimiter;
                inputVertical *= speedLimiter;
            }
            rb.velocity = new Vector2(inputHorizontal * walkSpeed, inputVertical * walkSpeed);
        }
        else
        {
            rb.velocity = new Vector2(0f, 0f);
        }
    }
}