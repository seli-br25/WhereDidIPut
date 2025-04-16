using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashRespawning : MonoBehaviour
{
    public GameObject otherTrash;
    public BoxCollider otherCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trashbin"))
        {
            otherTrash.SetActive(true);
            otherCollider.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Trashbin"))
        {
            otherTrash.SetActive(false);
            otherCollider.enabled = false;
        }
    }
}
