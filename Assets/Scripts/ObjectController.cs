using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.XR;
using UnityEngine.UI;

public class ObjectController : MonoBehaviour
{
    // Inventory script
	private InventoryCore inv;
    // TextDisplay script
    private DisplayText textDisplayer;

    /// <value>Material used when hovering over an object</value>
	public Material heldMat;
    /// <value>Player GameObject</value>
	public GameObject player;
    /// <value>Name of object, used for InventoryCore</value>
	public string objectName = "";

    // Starting function
	void Start()
	{
		inv = player.GetComponent<InventoryCore>();
        textDisplayer = GameObject.Find("DisplayText").GetComponent<DisplayText>();
	}

    // Google XR pointer enter
	void OnPointerEnter()
	{
		if (gameObject.name == "Flashlight") // Special case
			return;
		var mats = gameObject.GetComponent<MeshRenderer>().materials;
		mats[mats.Length - 1] = heldMat; // ObjectPickup is last material
		gameObject.GetComponent<MeshRenderer>().materials = mats;
	}

    // Google XR pointer leave
	void OnPointerExit()
	{
		var mats = gameObject.GetComponent<MeshRenderer>().materials;
		mats[1] = null;
		gameObject.GetComponent<MeshRenderer>().materials = mats;
	}

    // Google XR pointer click
	void OnPointerClick()
	{
		string _name = string.IsNullOrEmpty(objectName) ? gameObject.name : objectName;
		if (inv.AddItem(_name))
		{
            textDisplayer.Display($"Picked up <b><color=teal>{_name}</color></b>.", 2);
			gameObject.SetActive(false);
		}
	}
}
