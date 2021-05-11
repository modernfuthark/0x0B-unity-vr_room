using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour
{
    public string InteractionText;
    public int fadeDelay;
    private DisplayText tp;

    void start()
    {
        tp = GameObject.Find("DisplayText").GetComponent<DisplayText>();
    }
    void OnPointerClick()
    {
        tp.Display(InteractionText, fadeDelay);
    }
}
