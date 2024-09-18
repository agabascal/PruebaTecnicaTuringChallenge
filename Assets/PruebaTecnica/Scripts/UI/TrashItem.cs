using UnityEngine;

public class TrashItem : MonoBehaviour, IInventoryItem
{
    [SerializeField] private AudioClip trashSFX;

    private Item item;
    public Sprite ItemSprite => item.ItemSprite;

    private void Awake()
    {
        item = GetComponent<Item>();
    }

    public void UseItem()
    {
        Debug.Log("Cannot use trash.");
    }

    public void RemoveItem()
    {
        Debug.Log("Trash removed.");
        SFXManager.Instance.PlayClip(trashSFX);
    }
}

public class TrashUsageCommand : IItemUsageCommand
{
    private readonly TrashItem trash;

    public TrashUsageCommand()
    {
    }

    public void Execute()
    {

    }
}

