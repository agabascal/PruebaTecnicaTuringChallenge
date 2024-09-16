using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Grenade : MonoBehaviour
{
    public static event Action<float> GrenadeGrabbed;

    [SerializeField] private float damageAmount = -20;

    private XRGrabInteractable interactable;

    private void Awake()
    {
        interactable = GetComponent<XRGrabInteractable>();
    }

    private void OnEnable()
    {
        interactable.selectEntered.AddListener(OnGrenadeGrabbed);
    }

    private void OnDisable()
    {
        interactable.selectEntered.RemoveListener(OnGrenadeGrabbed);
    }

    private void OnGrenadeGrabbed(SelectEnterEventArgs _)
    {
        Debug.Log("Grenade Grabbed " + damageAmount);
        GrenadeGrabbed?.Invoke(damageAmount);
    }
}
