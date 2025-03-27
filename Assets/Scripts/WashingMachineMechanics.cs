using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashingMachineMechanic : MonoBehaviour
{
    private int clotheCount = 0;
    private int totalClothes = 1;
    public bool allClothesIn = false;
    public GameObject lid;
    private Vector3 lidClosedPosition;
    public GameObject clotheTaskTick;

    private void Start()
    {
        lidClosedPosition = lid.transform.position;
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
        if (other.CompareTag("Trash"))
        {
            clotheCount--;
            Debug.Log("Trash exited: " + clotheCount);
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
            if (lid.transform.position == lidClosedPosition)
            {
                Debug.Log("TASK DONE");
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
