using UnityEngine;

public interface IInventoryItem
{
    public GameObject gameObject { get; }
    public Sprite ItemSprite{ get; }
    public AudioClip ItemSFX{ get; }
    public void UseItem();
    public void RemoveItem();
}

