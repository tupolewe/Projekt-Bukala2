using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseBurnPosition : MonoBehaviour
{
     public PlayerController controller;

    public int burnPositionNumber = 0;

    
    void Update()
    {
        Debug.Log(controller.staticAnimationPlayed);
    }

    

    private void OnTriggerExit(Collider collider)
    {
        if (controller.staticAnimationPlayed == false)
        {
            if (collider.CompareTag("BurnPosition1"))
            {
                burnPositionNumber = 0;
            }
            else if (collider.CompareTag("BurnPosition2"))
            {
                burnPositionNumber = 0;
            }
            else if (collider.CompareTag("BurnPosition3"))
            {
                burnPositionNumber = 0;
            }
            else if (collider.CompareTag("BurnPosition4"))
            {
                burnPositionNumber = 0;
            }
        }    
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("BurnPosition1"))
        {
            burnPositionNumber = 1;
        }
        else if (collider.CompareTag("BurnPosition2"))
        {
            burnPositionNumber = 2;
        }
        else if (collider.CompareTag("BurnPosition3"))
        {
            burnPositionNumber = 3;
        }
        else if (collider.CompareTag("BurnPosition4"))
        {
            burnPositionNumber = 4;
        }
    }
}
