using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Used to manage the project and solve dependencies when no dependency injection framework has been
/// setup. Creates different subsystems used project-wide and passes corresponding references where needed
/// </summary>
public class EntryPoint : MonoBehaviour
{
    [SerializeField] private AmmoHUD ammoHUD;
    [SerializeField] private Ammo ammo;
    [SerializeField] private Potion potion;
    [SerializeField] private Grenade grenade;
    [SerializeField] private Inventory inventory;

    [SerializeField] private XRGrabInteractable grenadeInteractable;
    [SerializeField] private XRGrabInteractable potionInteractable;
    [SerializeField] private XRGrabInteractable ammoInteractable;

    private ItemCommand usableGrenadeItem;
    private ItemCommand usablePotionItem;
    private ItemCommand usableAmmoItem;

    private void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        usableGrenadeItem = new ItemCommand(new GrenadeUsageCommand(grenade, ammoHUD));
        usablePotionItem = new ItemCommand(new PotionUsageCommand(potion));
        usableAmmoItem = new ItemCommand(new AmmoUsageCommand(ammo));

        var handleGrenade = new ItemHandling(grenadeInteractable, usableGrenadeItem, inventory);
        handleGrenade.Initialize();
        var handlePotion = new ItemHandling(potionInteractable, usablePotionItem, inventory);
        handlePotion.Initialize();
        var handleAmmo = new ItemHandling(ammoInteractable, usableAmmoItem, inventory);
        handleAmmo.Initialize();
    }
}
