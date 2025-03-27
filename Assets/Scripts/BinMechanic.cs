using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinMechanic : MonoBehaviour
{
    private int trashCount = 0;
    private int numberOfTrash = 4;
    public bool taskDone = false;
    public GameObject trashTaskTick;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            trashCount++;
            Debug.Log("Trash entered: " + trashCount);
            audioSource.Play();
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
