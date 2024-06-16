using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeDeathScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("death");
        }
    }
}
