using UnityEngine;

public interface IInventoryItem
{
    public GameObject gameObject { get; }
    public Sprite ItemSprite{ get; }
    public void UseItem();
    public void RemoveItem();
}

