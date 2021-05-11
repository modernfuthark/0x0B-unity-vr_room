using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour
{
	/// <value>InteractionText string value</value>
	public string InteractionText;
	/// <value>Text fade out delay</value>
	public float fadeDelay;
	// DisplayText script
	private DisplayText td;

	// Unity start function
	void Start()
	{
		td = GameObject.Find("DisplayText").GetComponent<DisplayText>();
	}

	// Google XR pointer click
	void OnPointerClick()
	{
		td.Display(InteractionText, fadeDelay);
	}
}
