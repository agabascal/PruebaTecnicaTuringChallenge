using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private int ammoAmount = 2;
    [SerializeField] private AudioClip sfx;

    public int Amount => ammoAmount;
    public AudioClip Sfx => sfx;
}

public class AmmoUsageCommand : IItemUsageCommand
{
    private readonly Ammo ammo;

    public AmmoUsageCommand(Ammo ammo)
    {
        this.ammo = ammo;
    }
    public void Execute()
    {
        EventManager.IncreaseAmmo(ammo.Amount);
        SFXManager.Instance.PlayClip(ammo.Sfx);

    }
}
