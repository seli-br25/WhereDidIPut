using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinMechanic : MonoBehaviour
{
    private int trashCount = 0;
    private int numberOfTrash = 4;
    public bool taskDone = false;
    public GameObject trashTaskTick;
    public AudioSource trash;
    public AudioSource success;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            trashCount++;
            Debug.Log("Trash entered: " + trashCount);
            trash.Play();
            if (trashCount >= numberOfTrash)
            {
                taskDone = true;
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
