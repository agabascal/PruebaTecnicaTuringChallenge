using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Potion : MonoBehaviour
{
    public static event Action<float> Grabbed;

    [SerializeField] private float healAmount = 15;

    private XRGrabInteractable interactable;

    private void Awake()
    {
        interactable = GetComponent<XRGrabInteractable>();
    }

    private void OnEnable()
    {
        interactable.selectEntered.AddListener(OnPotionGrabbed);
    }

    private void OnDisable()
    {
        interactable.selectEntered.RemoveListener(OnPotionGrabbed);
    }

    private void OnPotionGrabbed(SelectEnterEventArgs _)
    {
        Debug.Log("Potion Grabbed " + healAmount);
        Grabbed?.Invoke(healAmount);
    }
}
