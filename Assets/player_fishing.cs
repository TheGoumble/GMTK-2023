using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Tilemaps;
using UnityEngine;

public class player_fishing : MonoBehaviour
{
    
    [SerializeField] GameObject rod_go;
    [SerializeField] GameObject pivot_go;
    [SerializeField] GameObject target_a_go;
    [SerializeField] float rodSpeed;
    private Quaternion lookRotation;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(target_a_go.transform.position.x - transform.position.x, target_a_go.transform.position.y - transform.position.y).normalized;

        lookRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rodSpeed);
        


    }
}
