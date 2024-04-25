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
        navMeshAgent.enabled = false;

    }



    // Update is called once per frame
    void Update()
    {
        //VaseBurning();

    }

    public void VaseBurning()
    {
        navMeshAgent.enabled = true;
        navMeshAgent.updateRotation = false;
    }

    public void WallHandling()
    {
        navMeshAgent.enabled = true;
        navMeshAgent.updateRotation = true;
        Player.transform.rotation = Quaternion.Euler(0, 270, 0); 
    }
}
