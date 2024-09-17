using UnityEngine;

public class TrashItem : MonoBehaviour, IInventoryItem
{
    public Color ItemColor => Color.magenta; 

    public void UseItem()
    {
        Debug.Log("Cannot use trash.");
    }

    public void RemoveItem()
    {
        Debug.Log("Trash removed.");
        Destroy(gameObject);
    }
}
