using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private float damageAmount = -20;
    [SerializeField] private AudioClip sfx;

    public float DamageAmount => damageAmount;
    public AudioClip Sfx => sfx;
}

public class GrenadeUsageCommand : IItemUsageCommand
{
    private readonly Grenade grenade;
    private readonly AmmoHUD ammoHUD;

    public GrenadeUsageCommand(Grenade grenade, AmmoHUD ammoHUD)
    {
        this.grenade = grenade;
        this.ammoHUD = ammoHUD;
    }
    public void Execute()
    {
        if (ammoHUD.CurrentAmmo > 0)
        {
            Debug.Log("Grenade Used, damaged for: " + grenade.DamageAmount);
            EventManager.OnDamageTaken(grenade.DamageAmount);
            EventManager.OnAmmoChanged(-1);
            SFXManager.Instance.PlayClip(grenade.Sfx);
        }
        else
        {
            Debug.Log("No Ammo left, discarding grenade");
        }
    }
}
