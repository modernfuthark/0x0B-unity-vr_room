using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskInteraction : MonoBehaviour
{
    /// <value>Player gameobject</value>
    public GameObject player;
    /// <value>Power core gameobject</value>
    public GameObject powerCore;
    /// <value>Projector gameobject</value>
    public GameObject projector;

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
        if (powerCore.activeSelf)
        {
            if (inventory.HasItem("Indentification Key"))
            {
                if (!projector.GetComponent<ProjectorController>().Unlocked)
                {
                    td.Display("Unlocked projector", 1.5f);
                    projector.GetComponent<ProjectorController>().Unlocked = true;
                }
                else
                    td.Display("Projector already unlocked", 1.5f);
            }
            else
                td.Display("Missing identification key", 1.5f);
        }
        else
            td.Display("There is no power", 1.5f);
    }
}
