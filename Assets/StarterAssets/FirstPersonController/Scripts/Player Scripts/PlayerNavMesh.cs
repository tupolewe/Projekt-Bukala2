using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class PlayerNavMesh : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;
    public NavMeshAgent navMeshAgent;
    public bool isHandlingTriggered = false;
    public GameObject Player;
    public animationStateController animationStateController;
    public VaseBurnPosition vaseBurnPosition;
    public bool canWallHandle = false;
    public DzbanScript dzbanScript;
    public TorchHandlerScript torchHandlerScript;



    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();


    }



    // Update is called once per frame
    void Update()
    {
        MoveToHandlePosition();

    }

    void MoveToHandlePosition()
    {
        bool movementKey = Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.D);
        if (movementKey)
        {
            navMeshAgent.enabled = false;

        }



        if (isHandlingTriggered && canWallHandle)
        {
            if (animationStateController.isHandlingRunning)
            {
                navMeshAgent.enabled = true;
                navMeshAgent.destination = torchHandlerScript.HandlePosition.transform.position;
                navMeshAgent.updateRotation = false;
                Player.transform.rotation = Quaternion.Euler(0, 270, 0);




            }
        }
        if (isHandlingTriggered)
        {
            if (vaseBurnPosition.burnPositionNumber == 1)
            {
                navMeshAgent.enabled = true;
                isHandlingTriggered = false;
                navMeshAgent.updateRotation = false;
                navMeshAgent.destination = dzbanScript.BurnPosition1.transform.position;
            }
            else if (vaseBurnPosition.burnPositionNumber == 2)
            {
                navMeshAgent.enabled = true;
                navMeshAgent.destination = dzbanScript.BurnPosition2.transform.position;
                isHandlingTriggered = false;
                navMeshAgent.updateRotation = false;
            }
            else if (vaseBurnPosition.burnPositionNumber == 3)
            {
                navMeshAgent.enabled = true;
                navMeshAgent.destination = dzbanScript.BurnPosition3.transform.position;
                isHandlingTriggered = false;
                navMeshAgent.updateRotation = false;
            }
            else if (vaseBurnPosition.burnPositionNumber == 4)
            {
                navMeshAgent.enabled = true;
                navMeshAgent.destination = dzbanScript.BurnPosition4.transform.position;
                isHandlingTriggered = false;
                navMeshAgent.updateRotation = false;
            }


        }
    }
}
