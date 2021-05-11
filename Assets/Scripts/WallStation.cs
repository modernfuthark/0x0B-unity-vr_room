using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallStation : MonoBehaviour
{
    /// <value>Player gameobject</value>
    public GameObject player;
    /// <value>"Power core" gameobject</value>
    public GameObject powerCore;

    // InventoryCore script
    private InventoryCore inventory;
    // DisplayText script
    private DisplayText td;

    // Unity start function
    void Start()
    {
        inventory = player.GetComponent<InventoryCore>();
        td = GameObject.Find("DisplayText").GetComponent<DisplayText>();
    }

    // Google XR pointer click
    void OnPointerClick()
    {
        if (inventory.HasItem("Power Core"))
        {
            inventory.RemoveItem("Power Core");
            td.Display("You placed the power core into the wall station");
            powerCore.SetActive(true);
        }
        else
        {
            if (powerCore.activeSelf)
                td.Display("The power core is now in place");
            else
                td.Display("This station seems to be missing something");
        }
    }
}
