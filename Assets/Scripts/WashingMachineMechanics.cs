using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashingMachineMechanic : MonoBehaviour
{
    private int clotheCount = 0;
    private int totalClothes = 4;
    public bool allClothesIn = false;
    public GameObject lid;
    private Vector3 lidClosedPosition;
    public GameObject clotheTaskTick;
    public GameObject offLight;
    public GameObject onLight;

    private void Start()
    {
        lidClosedPosition = lid.transform.position;
        offLight.SetActive(true);
        onLight.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Clothes"))
        {
            clotheCount++;
            Debug.Log("Clothe entered: " + clotheCount);
            if (clotheCount >= totalClothes)
            {
                allClothesIn = true;
                Debug.Log("All dirty clothes are in!");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Clothes"))
        {
            clotheCount--;
            Debug.Log("Clothe exited: " + clotheCount);
            if (clotheCount < totalClothes)
            {
                allClothesIn = false;
            }
        }
    }

    public void ButtonPressed()
    {
        if (allClothesIn)
        {
            float distance = Vector3.Distance(lidClosedPosition, lid.transform.position);
            if (distance < 0.01f) 
            {
                Debug.Log("TASK DONE");
                offLight.SetActive(false);
                onLight.SetActive(true);
                clotheTaskTick.SetActive(true);
            } else
            {
                Debug.Log("The lid is not closed! Please close it");
            }
        } else
        {
            Debug.Log("There are still dirty clothes missing!");
        }
    }
}
