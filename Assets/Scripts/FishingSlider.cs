using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class FishingSlider : MonoBehaviour
{
    [SerializeField] GameObject pointer;
    [SerializeField] GameObject text_go;
    [SerializeField] GameObject pp_go;
    private TMP_Text text;
    private Transform pointer_tf;
    private ParticleSystem pp;
    private bool direction;
    private bool moving;
    private bool jumpable;

    // Start is called before the first frame update
    void Start()
    {
        pointer_tf = pointer.GetComponent<Transform>();
        text = text_go.GetComponent<TMP_Text>();
        pp = pp_go.GetComponent<ParticleSystem>();
        direction = true;
        moving = true;
        jumpable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            if (pointer_tf.position.x < 2.79 && direction)
            {
                pointer_tf.position = new Vector2(pointer_tf.position.x + 0.005f, pointer_tf.position.y);
            }
            else if (pointer_tf.position.x > -2.79 && !direction)
            {
                pointer_tf.position = new Vector2(pointer_tf.position.x - 0.005f, pointer_tf.position.y);
            }
            if (pointer_tf.position.x > 2.79 || pointer_tf.position.x < -2.79)
            {
                direction = !direction;
            }
        }
     
        if (Input.GetKeyDown(KeyCode.Space) && jumpable)
        {
            moving = false;
            if ((pointer_tf.position.x >= -2.79 && pointer_tf.position.x < -1.895) || (pointer_tf.position.x <= 2.79 && pointer_tf.position.x > 1.895))
            {
                text.text = "TERRIBLE...";
                text.color = new Color(1f, 0.5f, 0.5f, 1f);
            }
            else if ((pointer_tf.position.x >= -1.895 && pointer_tf.position.x < -1.227) || (pointer_tf.position.x <= 1.895 && pointer_tf.position.x > 1.227))
            {
                text.text = "BAD";
                text.color = new Color(0.9f, 0.2f, 0.1f, 1f);
            }
            else if ((pointer_tf.position.x >= -1.227 && pointer_tf.position.x < -0.618) || (pointer_tf.position.x <= 1.227 && pointer_tf.position.x > 0.618))
            {
                text.text = "DECENT";
                text.color = new Color(1f, 0.64f, 0f, 1f);
            }
            else if ((pointer_tf.position.x >= -0.618 && pointer_tf.position.x < -0.161) || (pointer_tf.position.x <= 0.618 && pointer_tf.position.x > 0.161))
            {
                text.text = "GOOD!";
                text.color = new Color(0.6f, 0.7f, 0.1f, 1f);
            }
            else
            {
                text.text = "PERFECT!!";
                text.color = new Color(0f, 0.65f, 0.4f, 1f);
            }
            pp.Play();
            jumpable = false;
        }

    }
}
