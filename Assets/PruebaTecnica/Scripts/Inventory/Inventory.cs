using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<UIItem> inventorySlotsUI;
    [SerializeField] private Transform itemImageContainer;
    [SerializeField] private GameObject trashPrefab;

    private List<GameObject> items = new List<GameObject>();
    public static Inventory Instance { get; private set; }

    private void Awake()
    {
        inventorySlotsUI = new List<UIItem>();
        inventorySlotsUI.AddRange(itemImageContainer.GetComponentsInChildren<UIItem>());

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

    public void AddToInventory(GameObject item)
    {
        if (items.Count < inventorySlotsUI.Count && !items.Contains(item))
        {
            items.Add(item);
            item.SetActive(false);
            UpdateInventoryUI();
        }
    }

    public void UseItem(int slotIndex)
    {
        if (slotIndex < items.Count)
        {
            GameObject item = items[slotIndex];
            item.GetComponent<Item>().UseItem();

            Debug.Log("Used Object: " + item.name);

            var newTrash = Instantiate(trashPrefab);
            items[slotIndex] = newTrash;
            newTrash.SetActive(false);

            UpdateInventoryUI();
            inventorySlotsUI[slotIndex].SetupItemAsTrash(true); 
        }
    }

    public void RemoveItem(int slotIndex)
    {
        if (slotIndex < items.Count)
        {
            Item item = items[slotIndex].GetComponent<Item>();
            if (item != null)
            {
                item.GetComponent<Item>().RemoveItem();
                Debug.Log("Removed Object: " + item.name);
            }
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
                var item = items[i].GetComponent<Item>();

                if (item != null)
                {
                    inventorySlotsUI[i].GetComponent<Image>().color = item.ItemColor;
                    inventorySlotsUI[i].GetComponent<Button>().interactable = true;
                    inventorySlotsUI[i].GetComponent<UIItem>().SetupItemAsTrash(false);
                }
                else
                {
                    inventorySlotsUI[i].GetComponent<Image>().color = Color.magenta;
                    inventorySlotsUI[i].GetComponent<Button>().interactable = true;
                    inventorySlotsUI[i].GetComponent<UIItem>().SetupItemAsTrash(true);
                }
            }
            else
            {
                inventorySlotsUI[i].GetComponent<Image>().color = Color.grey;
                inventorySlotsUI[i].GetComponent<Button>().interactable = false;
            }
        }
    }
}
