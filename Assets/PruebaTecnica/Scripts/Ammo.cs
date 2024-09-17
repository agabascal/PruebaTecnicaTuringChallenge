using System;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public static event Action<int> AmmoUsed;

    [SerializeField] private int ammoAmount = 2;

    public void OnAmmoUsed()
    {
        AmmoUsed?.Invoke(ammoAmount);
    }
}
