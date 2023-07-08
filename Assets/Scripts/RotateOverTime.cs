using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOverTime : MonoBehaviour
{

    public float minSpeed = 30f;
    public float maxSpeed = 90f;

    private float rotationSpeed;
    private int rotationDirection;

    void Start()
    {
        // Generate random speed and direction
        rotationSpeed = Random.Range(minSpeed, maxSpeed);
        rotationDirection = Random.value < 0.5f ? -1 : 1; // -1 for left, 1 for right
    }

    void Update()
    {
        // Rotate object in the randomly determined direction and speed
        transform.Rotate(new Vector3(0f, 0f, rotationDirection * rotationSpeed * Time.deltaTime));
    }
}
