using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_fishing : MonoBehaviour
{
    
    [SerializeField] GameObject rod_go;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rod_go.transform.RotateAround(new Vector3(0.41f, 0.31f, 0f), new Vector3(0,0,1), 20);
        }
    }
}
