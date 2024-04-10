using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class RayCastInteraction : MonoBehaviour
{
    public float radius;
    public float maxDistance;

    public GameObject player;





    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void Update()
    {
        RayInteraction();
    }

    public void RayInteraction()
    {

        RaycastHit hit;

        Vector3 p1 = transform.position;
       

        
        if (Physics.SphereCast(p1, radius, transform.forward, out hit, 1))
        {
            
            Debug.Log(hit.collider);
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

            
