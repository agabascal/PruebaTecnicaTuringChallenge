using UnityEngine.Events;

public class ItemCommand
{
    public UnityEvent ItemUsed = new();

    private readonly IItemUsageCommand itemUsageCommand;

    public ItemCommand(IItemUsageCommand itemUsageCommand)
    {
        this.itemUsageCommand = itemUsageCommand;
    }

    public void Use()
    {
        itemUsageCommand.Execute();
        ItemUsed?.Invoke();
    }
}