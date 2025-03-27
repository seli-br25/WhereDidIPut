using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public AudioSource washingMachine;
    public AudioSource success;
     public TMP_Text sockText;

    private void Start()
    {
        lidClosedPosition = lid.transform.position;
        offLight.SetActive(true);
        onLight.SetActive(false);
        sockText.text = "Dirty socks colltected: " + clotheCount + "/" + totalClothes;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Clothes"))
        {
            clotheCount++;
            Debug.Log("Clothe entered: " + clotheCount);
            sockText.text = "Dirty socks colltected: " + clotheCount + "/" + totalClothes;
            if (clotheCount >= totalClothes)
            {
                allClothesIn = true;
                Debug.Log("All dirty clothes are in!");
                sockText.text = "All dirty clothes are in!";
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
                sockText.text = "Washing successfully started!";
                offLight.SetActive(false);
                onLight.SetActive(true);
                clotheTaskTick.SetActive(true);
                washingMachine.Play();
                success.Play();
            } else
            {
                Debug.Log("The lid is not closed! Please close it");
                sockText.text = "The lid is not closed! Please close it";
            }
        } else
        {
            Debug.Log("There are still dirty clothes missing!");
        }
    }
}
