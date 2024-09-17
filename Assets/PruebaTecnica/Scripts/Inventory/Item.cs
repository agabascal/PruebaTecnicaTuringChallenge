using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class InventoryItem : MonoBehaviour
{
    public UnityEvent ItemUsed;
    [SerializeField] private Color itemColor;
    [SerializeField] private Sprite itemSprite;

    public Color ItemColor => itemColor;

    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnSelectEnter);
    }

    private void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnSelectEnter);
    }

    private void OnSelectEnter(SelectEnterEventArgs _) => Inventory.Instance.AddToInventory(gameObject);

    public void UseItem()
    {
        ItemUsed?.Invoke();
        this.gameObject.SetActive(true);
    }
}
