using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesMechanic : MonoBehaviour
{
    public GameObject otherSock;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WashinMachine"))
        {
            otherSock.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("WashinMachine"))
        {
            otherSock.SetActive(false);
        }
    }
}
