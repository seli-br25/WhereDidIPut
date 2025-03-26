using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMechanic : MonoBehaviour
{
    private int trashCount = 0;
    private int numberOfTrash = 0;
    public bool taskDone = false;
    public GameObject trashTaskTick;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            trashCount++;
            Debug.Log("Trash entered: " + trashCount);
            if (trashCount >= numberOfTrash)
            {
                taskDone = true;
                Debug.Log("TASK COMPLETE!");
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
