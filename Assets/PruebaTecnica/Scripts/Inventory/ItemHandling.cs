using UnityEngine.XR.Interaction.Toolkit;
/// <summary>
/// 
/// </summary>
public class ItemHandling
{
    private readonly XRGrabInteractable grabInteractable;
    private readonly ItemCommand itemCommand;
    private readonly Inventory inventory;

    public ItemHandling(XRGrabInteractable grabInteractable, ItemCommand itemCommand, Inventory inventory)
    {
        this.grabInteractable = grabInteractable;
        this.itemCommand = itemCommand;
        this.inventory = inventory;
    }

    public void Initialize()
    {
        grabInteractable.selectEntered.AddListener(OnXRInteractableSelected);
        itemCommand.ItemUsed.AddListener(OnItemUsed);
    }

    public void Dispose()
    {
        grabInteractable.selectEntered.RemoveListener(OnXRInteractableSelected);
        itemCommand.ItemUsed.RemoveListener(OnItemUsed);
    }

    private void OnXRInteractableSelected(SelectEnterEventArgs _)
    {
        grabInteractable.gameObject.SetActive(false);
        // inventory.AddToInventory(itemWithCommandPattern);
    }

    private void OnItemUsed()
    {
        grabInteractable.gameObject.SetActive(true);
        // inventory.Remove(itemWithCommandPattern);
        // inventory.AddTrash();
    }
}
