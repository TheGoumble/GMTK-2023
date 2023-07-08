using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class player_fishing : MonoBehaviour
{
    
    [SerializeField] GameObject rod_go;
    [SerializeField] GameObject pivot_go;
    private SpriteRenderer rod_sr;
    float rotat = 0;

    // Start is called before the first frame update
    void Start()
    {
        rod_sr = rod_go.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rod_go.transform.rotation.z > -60)
        {
            rod_go.transform.RotateAround(pivot_go.transform.position, new Vector3(0, 0, 1), -0.01f);
        }
        //if (rod_go.transform.rotation.z < -60)
        //{
        //    rotat = 0;
        //}
        //rod_go.transform.RotateAround(pivot_go.transform.position, new Vector3(0,0,1), rotat * Time.deltaTime);
        //if (Input.GetMouseButtonDown(0))
        //{
        //    rotat = -300;
        //}
        
    }
}
