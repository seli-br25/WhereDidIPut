using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BinMechanic : MonoBehaviour
{
    private int trashCount = 0;
    private int numberOfTrash = 4;
    public bool taskDone = false;
    public GameObject trashTaskTick;
    public AudioSource trash;
    public AudioSource success;
    public TMP_Text trashText;

    private void Start()
    {
        trashText.text = "Trash colltected: " + trashCount + "/" + numberOfTrash;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            trashCount++;
            Debug.Log("Trash entered: " + trashCount);
            trashText.text = "Trash colltected: " + trashCount + "/" + numberOfTrash;

            trash.Play();
            if (trashCount >= numberOfTrash)
            {
                taskDone = true;
                trashText.text = "Cleanup complete!";
                Debug.Log("TASK COMPLETE!");
                success.Play();
                trashTaskTick.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            trashCount--;
            Debug.Log("Trash exited: " + trashCount);
            if (trashCount < numberOfTrash)
            {
                taskDone = false;
            }
        }
    }
}
