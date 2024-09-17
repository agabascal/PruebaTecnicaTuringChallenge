using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<UIItem> inventorySlotsUI;
    [SerializeField] private Transform itemImageContainer;
    [SerializeField] private GameObject trashPrefab;
    [SerializeField] private AudioClip pickupSFX;
    [SerializeField] private AudioClip itemRejectedSFX;

    private List<IInventoryItem> items = new List<IInventoryItem>();

    private AudioSource audioSource;
    public static Inventory Instance { get; private set; }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
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
        inventorySlotsUI = new List<UIItem>();
        inventorySlotsUI.AddRange(itemImageContainer.GetComponentsInChildren<UIItem>());
    }

    public void AddToInventory(IInventoryItem item)
    {
        if (items.Count < inventorySlotsUI.Count && !items.Contains(item))
        {
            items.Add(item);
            item.gameObject.SetActive(false);
            audioSource.clip = pickupSFX;
            audioSource.Play();
            UpdateInventoryUI();
        }
        else
        {
            audioSource.clip = itemRejectedSFX;
            audioSource.Play();
        }
    }

    public void UseItem(int slotIndex)
    {
        if (slotIndex < items.Count)
        {
            IInventoryItem item = items[slotIndex];
            item.UseItem();
            Debug.Log("Used Object: " + item.GetType().Name);
            audioSource.clip = item.ItemSFX;
            audioSource.Play();
            CreateTrashInSlot(slotIndex);
        }
    }

    private void CreateTrashInSlot(int slotIndex)
    {
        var trashItem = Instantiate(trashPrefab).GetComponent<IInventoryItem>();
        items[slotIndex] = trashItem;
        UpdateInventoryUI();
        inventorySlotsUI[slotIndex].SetupItemAsTrash(true);
    }

    public void RemoveItem(int slotIndex)
    {
        if (slotIndex < items.Count)
        {
            IInventoryItem item = items[slotIndex];
            item.RemoveItem();
            Debug.Log("Removed Object: " + item.GetType().Name);
            items.RemoveAt(slotIndex);
            UpdateInventoryUI();
        }
    }

    private void UpdateInventoryUI()
    {
        for (int i = 0; i < inventorySlotsUI.Count; i++)
        {
            if (i < items.Count)
            {
                UpdateSlot(i, items[i]);
            }
            else
            {
                ClearSlot(i);
            }
        }
    }

    private void UpdateSlot(int slotIndex, IInventoryItem item)
    {
        var slotUI = inventorySlotsUI[slotIndex];
        slotUI.GetComponent<Image>().sprite = item.ItemSprite;
        slotUI.GetComponent<Button>().interactable = true;
        slotUI.SetupItemAsTrash(item is TrashItem);
    }

    private void ClearSlot(int slotIndex)
    {
        var slotUI = inventorySlotsUI[slotIndex];
        slotUI.GetComponent<Image>().sprite = null;
        slotUI.GetComponent<Button>().interactable = false;
    }
}
