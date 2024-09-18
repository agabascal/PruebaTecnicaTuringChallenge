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

    [SerializeField] private Item grenadeItem;
    [SerializeField] private Item potionItem;
    [SerializeField] private Item ammoItem;

    [SerializeField] private XRGrabInteractable grenadeInteractable;
    [SerializeField] private XRGrabInteractable potionInteractable;
    [SerializeField] private XRGrabInteractable ammoInteractable;

    private ItemCommand usableGrenadeItem;
    private ItemCommand usablePotionItem;
    private ItemCommand usableAmmoItem;

    private ItemHandling handleGrenade;
    private ItemHandling handlePotion;
    private ItemHandling handleAmmo;

    private void Awake()
    {
        Initialize();
    }

    private void OnDestroy()
    {
        handleGrenade.Dispose();
        handleAmmo.Dispose();
        handlePotion.Dispose();
    }

    public void Initialize()
    {
        usableGrenadeItem = new ItemCommand(new GrenadeUsageCommand(grenade, ammoHUD), grenadeItem);
        usablePotionItem = new ItemCommand(new PotionUsageCommand(potion), potionItem);
        usableAmmoItem = new ItemCommand(new AmmoUsageCommand(ammo), ammoItem);

        handleGrenade = new ItemHandling(grenadeInteractable, usableGrenadeItem, inventory);
        handleGrenade.Initialize();
        handlePotion = new ItemHandling(potionInteractable, usablePotionItem, inventory);
        handlePotion.Initialize();
        handleAmmo = new ItemHandling(ammoInteractable, usableAmmoItem, inventory);
        handleAmmo.Initialize();
    }
}
