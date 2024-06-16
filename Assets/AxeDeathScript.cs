using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeDeathScript : MonoBehaviour
{


    public HealthScript HealthScript;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            HealthScript.Death();
        }
    }
}
