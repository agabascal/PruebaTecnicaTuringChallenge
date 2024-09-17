using UnityEngine;
using TMPro;
using System;

public class AmmoHUD : MonoBehaviour
{
    [SerializeField] private int startingAmmo;
    [SerializeField] private TMP_Text ammoText;

    private int currentAmmo;

    public int CurrentAmmo => currentAmmo;

    private void Awake()
    {
        currentAmmo = startingAmmo;
        UpdateUI();
    }

    private void OnEnable()
    {
        EventManager.OnAmmoChanged += UpdateAmmo;
    }

    private void OnDisable()
    {
        EventManager.OnAmmoChanged -= UpdateAmmo;
    }

    private void UpdateAmmo(int ammo)
    {
        currentAmmo += ammo;
        currentAmmo = Mathf.Clamp(currentAmmo, 0, 10);
        UpdateUI();
    }

    private void UpdateUI()
    {
        ammoText.SetText("Ammo: " + currentAmmo +"/" + "10");
    }
}
