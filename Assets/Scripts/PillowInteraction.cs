using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillowInteraction : MonoBehaviour
{
    /// <value>Pillow end position</value>
    public GameObject endPillow;

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
        td.Display("You move the pillow", 1.5f);
        endPillow.SetActive(true);
        gameObject.SetActive(false);
    }
}
