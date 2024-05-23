using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class RayCastInteraction : MonoBehaviour
{
    public float sphereRadius;
    public float maxDistance;
    public LayerMask layerMask;
    public GameObject player;
    

    private Vector3 origin;
    private Vector3 direction;

    public float currentHitDistance;
    public GameObject currentHitObject;


    public VaseBurnPosition vaseBurnPosition;
    public PlayerNavMesh playerNavMesh;

    
    public DzbanScript dzbanScript;




    

    void Update()
    {
        RayInteraction();
    }

    public void RayInteraction()
    {

        origin = transform.position;
        direction = transform.forward;
        //RaycastHit hit;

        if (Physics.SphereCast(origin, sphereRadius, direction, out RaycastHit hit, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal))
        {
            currentHitObject = hit.transform.gameObject;
            currentHitDistance = hit.distance;

            Interactable interactable = hit.collider.GetComponent<Interactable>();



            if (interactable != null)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();

                }
            }
            if (hit.collider.GetComponent("DzbanScript") != null)
            {
                vaseBurnPosition.burnPositionNumber = UnityEngine.Random.Range(1, 4);
                Debug.Log(vaseBurnPosition.burnPositionNumber);
            }

        }
        else
        {
            currentHitObject = null;
            currentHitDistance = maxDistance;
            

        }

        
            

        if (hit.collider.CompareTag("Torch Handler"))
        {
            playerNavMesh.canWallHandle = true;
        }
        else
        {
            playerNavMesh.canWallHandle = false;
        }
        





    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Debug.DrawLine(origin, origin + direction * currentHitDistance);
        Gizmos.DrawWireSphere(origin + direction * currentHitDistance, sphereRadius);
    }
}


