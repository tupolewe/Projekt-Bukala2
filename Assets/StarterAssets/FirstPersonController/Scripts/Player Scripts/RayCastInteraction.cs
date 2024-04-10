using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastInteraction : MonoBehaviour
{
    public float range = 4f;







    void Update()
    {
        RayInteraction();
    }

    public void RayInteraction()
    {
        Vector3 direction = Vector3.forward;
        Ray ray = new Ray(transform.position, transform.TransformDirection(direction * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * range));

        if (Physics.Raycast(ray, out RaycastHit hit, range))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            //Debug.Log(hit.collider);

            if (interactable != null)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                    Debug.Log("interact");
                }

            }
            
            
            

         }


    }
}

            
