using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    private string biome;
    private int healthToHeal;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject managerHolder = new GameObject("[Game Manager]");
                managerHolder.AddComponent<GameManager>();
            }

            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetBiome(string biome)
    {
        this.biome = biome;
    }

    public string GetBiome()
    {
        return this.biome;
    }

    public void SetHealthToHeal(int health)
    {
        healthToHeal = health;
    }

    public int GetHealthToHeal()
    {
        return healthToHeal;
    }
}
