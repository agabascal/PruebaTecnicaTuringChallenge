using UnityEngine;

public interface IInventoryItem
{
    public Color ItemColor { get; }
    public void UseItem();
    public void RemoveItem();
}

