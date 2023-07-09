using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    private SpriteRenderer sr;
    private Material material;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        material = sr.material;

    }

    private void Update()
    {
        //material.mainTexture = sr.sprite.texture;
        material.SetTexture("MainTex", sr.sprite.texture);
    }
}
