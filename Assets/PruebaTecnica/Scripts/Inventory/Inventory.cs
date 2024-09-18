using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<UIItem> inventorySlotsUI;
    [SerializeField] private Transform itemImageContainer;
    [SerializeField] private GameObject trashPrefab;
    [SerializeField] private AudioClip pickupSFX;
    [SerializeField] private AudioClip inventoryFullSFX;
    [SerializeField] private AudioClip discardSFX;

    private List<ItemCommand> items = new List<ItemCommand>();
    public static Inventory Instance { get; private set; }

    public bool CanAddToInventory => items.Count < inventorySlotsUI.Count;

    private void Awake()
    {
        InitializeInventorySlots();

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        UpdateInventoryUI();
    }

    private void InitializeInventorySlots()
    {
        inventorySlotsUI = itemImageContainer.GetComponentsInChildren<UIItem>().ToList();
    }

    public void AddToInventory(ItemCommand item)
    {
        if (CanAddToInventory && !items.Contains(item))
        {
            items.Add(item);
            inventorySlotsUI[items.IndexOf(item)].SetupItemAsTrash(false);
            SFXManager.Instance.PlayClip(pickupSFX);
            UpdateInventoryUI();
        }
        else
        {
            SFXManager.Instance.PlayClip(inventoryFullSFX);
        }
    }

    public void UseItem(int slot)
    {
        var item = items[slot];
        if (item != null)
        {
            item.Use();
            Debug.Log("Used Object: " + item.GetType().Name);

            CreateTrashInSlot(slot);
        }
    }

    private void CreateTrashInSlot(int slotIndex)
    {
        var trashInstance = Instantiate(trashPrefab).GetComponent<Item>();
        var trashItem = new ItemCommand(new TrashUsageCommand(), trashInstance);
        items[slotIndex] = trashItem;
        inventorySlotsUI[slotIndex].SetupItemAsTrash(true);
        UpdateInventoryUI();
    }

    public void RemoveItem(int slotIndex)
    {
        var item = items[slotIndex];
        if (item != null)
        {
            item.Remove();
            items.Remove(item);
            Debug.Log("Removed Object: " + item.GetType().Name);
            UpdateInventoryUI();
            if (slotIndex + 1 < inventorySlotsUI.Count)
            {
                if (inventorySlotsUI[slotIndex].IsTrash && !inventorySlotsUI[slotIndex + 1].IsTrash)
                {
                    inventorySlotsUI[slotIndex].SetupItemAsTrash(false);
                }
            }
            SFXManager.Instance.PlayClip(discardSFX);
        }
    }

    private void UpdateInventoryUI()
    {
        for (int i = 0; i < inventorySlotsUI.Count; i++)
        {
            if (i < items.Count)
            {
                UpdateSlot(inventorySlotsUI[i], items[i].Item);
            }
            else
            {
                ClearSlot(inventorySlotsUI[i]);
            }
        }
    }

    private void UpdateSlot(UIItem slotUI, IInventoryItem item)
    {
        slotUI.GetComponent<Image>().sprite = item.ItemSprite;
        slotUI.GetComponent<Button>().interactable = true;
    }

    private void ClearSlot(UIItem slotUI)
    {
        slotUI.GetComponent<Image>().sprite = null;
        slotUI.GetComponent<Button>().interactable = false;
    }

}

