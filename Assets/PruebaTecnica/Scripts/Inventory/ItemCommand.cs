using UnityEngine.Events;

[System.Serializable]
public class ItemCommand
{
    public UnityEvent ItemUsed = new();

    private readonly Item item;
    private readonly IItemUsageCommand itemUsageCommand;

    public Item Item => item;

    public ItemCommand(IItemUsageCommand itemUsageCommand, Item item)
    {
        this.itemUsageCommand = itemUsageCommand;
        this.item = item;
    }

    public void Use()
    {
        itemUsageCommand.Execute();
        ItemUsed?.Invoke();
        item.ResetItem();
    }

    public void Remove()
    {
        item.ResetItem();
    }
}