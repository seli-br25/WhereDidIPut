using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMechanic : MonoBehaviour
{
    private int trashCount = 0;
    public bool taskDone = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            trashCount++;
            Debug.Log("Trash entered: " + trashCount);
            if (trashCount >= 4)
            {
                taskDone = true;
                Debug.Log("Task complete!");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            trashCount--;
            Debug.Log("Trash exited: " + trashCount);
            if (trashCount < 4)
            {
                taskDone = false;
            }
        }
    }
}
