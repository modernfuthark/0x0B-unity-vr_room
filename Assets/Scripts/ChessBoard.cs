using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    // DisplayText script
    private DisplayText td;
    // InventoryCore script
    private InventoryCore inventory;
    /// <value>Player gameobject</value>
    public GameObject player;
    /// <value>White Knight gameobject</value>
    public GameObject wKnight;
    /// <value>Black Rook gameobject;
    public GameObject bRook;

    // Unity start function
    void Start()
    {
        
        td = GameObject.Find("DisplayText").GetComponent<DisplayText>();
        inventory = player.GetComponent<InventoryCore>();
    }

    // Google XR pointer click
    void OnPointerClick()
    {
        int has = 0;

        // Doesn't have any pieces -> Display missing
        // Has 1 piece -> Place down, remove from inventory
        if (!inventory.HasItem("Rook (Black)") && !inventory.HasItem("Knight (White)"))
        {
            if (wKnight.activeSelf)
                has++;
            if (bRook.activeSelf)
                has++;

            td.Display($"The board is missing {2 - has} piece{(has == 1 ? "" : "s")}", 2);
        }
        else
        {
            if (inventory.HasItem("Rook (Black)"))
            {
                inventory.RemoveItem("Rook (Black)");
                bRook.SetActive(true);
                has++;
            }
            if (inventory.HasItem("Knight (White)"))
            {
                inventory.RemoveItem("Knight (White)");
                wKnight.SetActive(true);
                has++;
            }
            if (has == 2)
                td.Display("You place down both chess pieces");
            else
                td.Display("You place down a chess piece");
        }
    }
}
