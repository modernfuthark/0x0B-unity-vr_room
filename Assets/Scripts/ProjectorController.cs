using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectorController : MonoBehaviour
{
    /// <value>Particle System game object</value>
    public GameObject particalSys;

    /// <value>Can be started</value>
    public bool Unlocked;

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
        if (!Unlocked)
        {
            td.Display("The projector isn't unlocked");
        }
        else if (!particalSys.activeSelf && Unlocked)
        {
            particalSys.SetActive(true);
            particalSys.GetComponent<ParticleSystem>().Play();
        }
	}
}
