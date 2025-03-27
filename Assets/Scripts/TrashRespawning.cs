using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashRespawning : MonoBehaviour
{
    public GameObject otherTrash;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trashbin"))
        {
            otherTrash.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Trashbin"))
        {
            otherTrash.SetActive(false);
        }
    }
}
