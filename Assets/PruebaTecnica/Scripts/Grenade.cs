using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Grenade : MonoBehaviour
{
    public static event Action<float> GrenadeGrabbed;

    [SerializeField] private float damageAmount = -20;

    public void OnGrenadeUsed()
    {
        GrenadeGrabbed?.Invoke(damageAmount);
    }
}
