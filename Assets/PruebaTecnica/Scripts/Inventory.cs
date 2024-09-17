﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory: MonoBehaviour
{
    [SerializeField] public List<GameObject> inventorySlotsUI;

    private List<GameObject> items = new List<GameObject>();
    public static Inventory Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }

    }
    public void AddToInventory(GameObject item)
    {
        if (items.Count < inventorySlotsUI.Count)
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
            Debug.Log("Used Object: " + item.name);
            items.RemoveAt(slotIndex);
        }
    }

    private void UpdateInventoryUI()
    {
        for (int i = 0; i < inventorySlotsUI.Count; i++)
        {
            if (i < items.Count)
            {
                inventorySlotsUI[i].GetComponent<Image>().color = items[i].GetComponent<InventoryItem>().ItemColor;
            }
            else
            {
                inventorySlotsUI[i].GetComponent<Image>().color = Color.white;
            }
        }
    }
}
