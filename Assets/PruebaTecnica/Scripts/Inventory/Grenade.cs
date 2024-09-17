using System;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public static event Action<float> GrenadeUsed;
    public static event Action<int> DecreaseAmmo;

    [SerializeField] private float damageAmount = -20;
    public void OnGrenadeUsed()
    {
        Debug.Log("Grenade Used, damaged for: " + damageAmount);
        GrenadeUsed?.Invoke(damageAmount);
        DecreaseAmmo?.Invoke(-1);
    }
}
