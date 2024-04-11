using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class RayCastInteraction : MonoBehaviour
{
    public float range;

    

    public GameObject player;





    

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



            if (interactable != null)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();

                }
            }


        }
    }
}


