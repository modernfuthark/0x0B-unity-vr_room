using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectorController : MonoBehaviour
{
    public GameObject particalSys;
	void OnPointerClick()
	{
        if (!particalSys.activeSelf)
        {
            particalSys.SetActive(true);
            particalSys.GetComponent<ParticleSystem>().Play();
        }
	}
}
