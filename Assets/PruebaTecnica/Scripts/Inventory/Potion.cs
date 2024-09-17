using System;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public static event Action<float> Grabbed;

    [SerializeField] private float healAmount = 15;

    public void OnPotionUsed()
    {
        Debug.Log("Potion Used, healed for: " + healAmount);
        Grabbed?.Invoke(healAmount);
    }
}
