using System;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public static event Action<int> AmmoObtained;

    [SerializeField] private int ammoAmount = 2;

    public void OnAmmoObtained()
    {
        AmmoObtained?.Invoke(ammoAmount);
    }
}
