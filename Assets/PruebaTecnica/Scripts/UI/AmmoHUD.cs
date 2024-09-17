using UnityEngine;
using TMPro;
using System;

public class AmmoHUD : MonoBehaviour
{
    [SerializeField] private int startingAmmo;
    [SerializeField] private TMP_Text ammoText;

    private int currentAmmo;

    private void Awake()
    {
        currentAmmo = startingAmmo;
        UpdateUI();
    }

    private void OnEnable()
    {
        Ammo.AmmoObtained += UpdateAmmo;
        Grenade.DecreaseAmmo += UpdateAmmo;
    }

    private void OnDisable()
    {
        Ammo.AmmoObtained -= UpdateAmmo;
        Grenade.DecreaseAmmo -= UpdateAmmo;
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
