using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    // Inventory gameobject
    private InventoryCore inventory;
    // DisplayText script
    private DisplayText td;
    /// <value>Console gameobject</value>
    public Text console;

    // Unity start function
    void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<InventoryCore>();
        td = GameObject.Find("DisplayText").GetComponent<DisplayText>();
    }

    // OnTriggerEnter function, door system
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if (inventory.HasItem("Door Card"))
            {
                console.text = "ACCESS GRANTED";
                console.color = Color.green;
                gameObject.GetComponent<Animator>().enabled = true;
                gameObject.GetComponent<Animator>().SetBool("character_nearby", true);
            }
            else
            {
                td.Display("It seems you're missing something...", 2);
                console.text = "ERROR: MISSING KEYCARD";
                console.color = Color.red;
            }
        }
    }

    // OnTriggerExit function, close door
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            gameObject.GetComponent<Animator>().SetBool("character_nearby", false);
        }
    }
}
