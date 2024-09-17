using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Item : MonoBehaviour, IInventoryItem
{
    public UnityEvent ItemUsed;
    [SerializeField] private Sprite itemSprite;
    [SerializeField] private AudioClip sfx;
    public Sprite ItemSprite => itemSprite;

    public AudioClip ItemSFX => sfx;

    private XRGrabInteractable grabInteractable;
    private Vector3 startPos;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        startPos = transform.position;
    }

    private void OnEnable()
    {
        transform.position = startPos;
        grabInteractable.selectEntered.AddListener(OnSelectEnter);
    }

    private void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnSelectEnter);
    }

    private void OnSelectEnter(SelectEnterEventArgs _)
    {
        Inventory.Instance.AddToInventory(this);
        gameObject.SetActive(false);
    }

    public void UseItem()
    {
        ItemUsed?.Invoke();
        this.gameObject.SetActive(true);
    }

    public void RemoveItem()
    {
        this.gameObject.SetActive(true);
    }
}
