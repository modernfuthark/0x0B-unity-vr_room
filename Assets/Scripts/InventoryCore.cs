using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCore : MonoBehaviour
{
    // The inventory in this game is just a dictionary of names
    // and an item amount, nothing fancy.

    // Inventory dictionary, string key used an name, int value used as item count
    private static Dictionary<string, int> inventory = new Dictionary<string, int>();

    // DisplayText script
    private DisplayText td;

    /// <value>Maximum inventory slots</value>
    public int MaximumSlots;
    /// <value> Maximum item stack size </value>
    public int MaxItemStack;
    /// <value>InventoryDisplay UI element</value>
    public Text inventoryDisplay;

    // Unity start function
    void Start()
    {
        td = GameObject.Find("DisplayText").GetComponent<DisplayText>();
    }

    /// <summary>
    /// Adds an item to the inventory
    /// </summary>
    /// <param name='_name'>Name of item to remove</param>
    /// <return>On success: True, false if failed</return>
    public bool AddItem(string _name)
    {
        if (inventory.Count >= MaximumSlots)
        {
            td.Display("You are holding too many items!", 1.5f);
            return false;
        }

        if (inventory.ContainsKey(_name))
        {
            if (inventory[_name] > MaxItemStack)
            {
                td.Display($"You can't hold any more {_name}", 1.5f);
                return false;
            }
            inventory[_name] += 1;
        }
        else
        {
            inventory[_name] = 1;
        }
        UpdateInventoryDisplay();
        return true;
    }

    /// <summary>
    /// Removes an item from the inventory
    /// </summary>
    /// <param name='_name'>Name of item to remove</param>
    /// <return>On success: True, false if failed</return>
    public bool RemoveItem(string _name)
    {
        if (!inventory.ContainsKey(_name))
            return false;

        inventory[_name] -= 1;
        if (inventory[_name] == 0)
            inventory.Remove(_name);

        UpdateInventoryDisplay();
        return true;
    }

    /// <summary>
    /// Updates the InventoryDisplay UI element
    /// </summary>
    public void UpdateInventoryDisplay()
    {
        string invTxt = "Inventory:\n";
        int i = 0;

        foreach(KeyValuePair<string, int> item in inventory)
        {
            invTxt += item.Key + (item.Value > 1 ? $" x{item.Value}" : "");
            if (i < inventory.Count - 1)
                invTxt += "\n";
            i++;
        }

        inventoryDisplay.text = invTxt;
    }

    /// <summary>
    /// Tests to check if the player has an item
    /// </summary>
    /// <param name='itemName'>Name of item to search for</param>
    /// <return>If found, returns true, if not, returns false</return>
    public bool HasItem(string itemName)
    {
        return inventory.ContainsKey(itemName);
    }
}
