using UnityEngine;
using TMPro;

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
        Ammo.AmmoUsed += IncreaseAmmo;
    }

    private void OnDisable()
    {
        Ammo.AmmoUsed -= IncreaseAmmo;
    }

    private void IncreaseAmmo(int ammo)
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
