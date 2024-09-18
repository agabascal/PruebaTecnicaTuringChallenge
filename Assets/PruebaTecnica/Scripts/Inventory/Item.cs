using UnityEngine;

public class Item : MonoBehaviour, IInventoryItem
{
    [SerializeField] private Sprite itemSprite;
    public Sprite ItemSprite => itemSprite;

    private Vector3 startPos;
    private Quaternion startRotation;

    private void Awake()
    {
        startPos = transform.position;
        startRotation = transform.rotation;
    }

    public void ResetItem()
    {
        this.gameObject.SetActive(true);
        transform.position = startPos;
        transform.rotation = startRotation;
    }
}
