﻿using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private float damageAmount = -20;
    [SerializeField] private AudioClip sfx;
    private AmmoHUD ammoHUD;

    private void Awake()
    {
        ammoHUD = FindObjectOfType<AmmoHUD>();
    }
    public void OnGrenadeUsed()
    {
        if (ammoHUD.CurrentAmmo > 0)
        {
            Debug.Log("Grenade Used, damaged for: " + damageAmount);
            EventManager.OnDamageTaken(damageAmount);
            EventManager.OnAmmoChanged(-1);
            SFXManager.Instance.PlayClip(sfx);
        }
        else
        {
            Debug.Log("No Ammo left");
        }
    }
}
