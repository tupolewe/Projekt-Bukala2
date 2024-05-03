using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.XR;

public class DzbanScript : MonoBehaviour, Interactable


{
    public animationStateController animationStateController;
    public PlayerController playerController;
    public VaseBurnPosition vaseBurnPosition;
    public PlayerNavMesh playerNavMesh;

   
    public bool torchInRange = false;
    public bool torchActive = true;
    private bool canPushD;
    public bool isOn = false;



    public int burnCount = 0;
    public Rigidbody playerRb;

    public GameObject Player;
    public GameObject PushingPosition;
    public GameObject Vase;
    public GameObject VaseLight;
    public GameObject Torch;

    public GameObject BurnPosition1;
    public GameObject BurnPosition2;
    public GameObject BurnPosition3;
    public GameObject BurnPosition4;
    public NavMeshAgent navMeshAgent;

    public Transform BurnTransform1;
    public Transform BurnTransform2;
    public Transform BurnTransform3;
    public Transform BurnTransform4;
    public Transform PlayerTransform;

    public bool VaseBurningActive;
    public float distanceToPosition = 10f;




    // Start is called before the first frame update
    void Start()
    {
        
        VaseLight.SetActive(false);
       
        
    }
    void Update()
    {
        TorchActiveCheck();
        NavMeshDestination();

        
       
    }

    void UpdateLight()
    {
        VaseLight.SetActive(true);
        isOn = true; 
         
    }

        


  public void Interact()
    {
        
       if (torchActive && !isOn && vaseBurnPosition.burnPositionNumber > 0)
            {
                VaseBurningActive = true;
                UpdateLight();
            
            }
         else if (isOn && !torchActive && !canPushD)
        {

            
            playerController.speed = 2;
            canPushD = true;
            animationStateController.canPushD = true;
            playerController.turnSpeed = 80;
            Vase.transform.position = PushingPosition.transform.position;
            Vase.transform.SetParent(Player.transform, true);
        }
        else if (isOn && !torchActive && canPushD)
        {
            
            playerController.speed = 4;
            animationStateController.canPushD = false;
            canPushD = false;
            Vase.transform.parent = null;
            playerController.turnSpeed = 340;

        }

        

        
        
       
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Torch"))
        {
            torchInRange = true;
        }
        else
        {
            torchInRange = false;
        }


    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Torch"))
        {
            torchInRange = false;
            burnCount = 0;
            
        }
    }

    public void TorchActiveCheck ()
    {
        if (Torch.activeInHierarchy == true) 
        {
            torchActive = true;
        }
        else if (Torch.activeInHierarchy == false)
        {
            torchActive = false;
        }

    }

    void BurnCount()
    {
        if (burnCount > 0) 
        {
            animationStateController.torchHandle = false;
            //Debug.Log(burnCount);
        }
    }

    void NavMeshDestination()
    {
        if (VaseBurningActive == true)
        {
            playerController.staticAnimationPlayed = true;
            playerNavMesh.VaseBurning();

            if (vaseBurnPosition.burnPositionNumber == 1)
            {
                Debug.Log("1");
                playerNavMesh.navMeshAgent.destination = BurnPosition1.transform.position;

                if (Vector3.Distance(PlayerTransform.position, BurnTransform1.position) < 2.5f)
                {
                    Debug.Log("numer 1");
                    Player.transform.rotation = Quaternion.Euler(0, -360, 0);
                    navMeshAgent.updateRotation = false;
                    animationStateController.animator.SetBool("torchHandler", true);
                    playerNavMesh.navMeshAgent.enabled = false;
                    VaseBurningActive = false;
                    animationStateController.isHandlingRunning = true;
                }
            }
            if (vaseBurnPosition.burnPositionNumber == 2)
            {

                playerNavMesh.navMeshAgent.destination = BurnPosition2.transform.position;
                Debug.Log("2");
                if (Vector3.Distance(PlayerTransform.position, BurnTransform2.position) < 2.5f)
                {
                    Debug.Log("numer 2");
                    Player.transform.rotation = Quaternion.Euler(0, 100, 0);
                    navMeshAgent.updateRotation = false;
                    animationStateController.animator.SetBool("torchHandler", true);
                    playerNavMesh.navMeshAgent.enabled = false;
                    VaseBurningActive = false;
                    animationStateController.isHandlingRunning = true;
                }
            }
            if (vaseBurnPosition.burnPositionNumber == 3)
            {

                playerNavMesh.navMeshAgent.destination = BurnPosition3.transform.position;
                Debug.Log("3");
                if (Vector3.Distance(PlayerTransform.position, BurnTransform3.position) < 2.5)
                {
                    Debug.Log("numer 3");
                    Player.transform.rotation = Quaternion.Euler(0, -90, 0);
                    navMeshAgent.updateRotation = false;
                    animationStateController.animator.SetBool("torchHandler", true);
                    playerNavMesh.navMeshAgent.enabled = false;
                    VaseBurningActive = false;
                    animationStateController.isHandlingRunning = true;
                }
            }
            if (vaseBurnPosition.burnPositionNumber == 4)
            {
                Debug.Log("4");
                playerNavMesh.navMeshAgent.destination = BurnPosition4.transform.position;

                if (Vector3.Distance(PlayerTransform.position, BurnTransform4.position) < 2.5f)
                {
                    Debug.Log("numer 4");
                    Player.transform.rotation = Quaternion.Euler(0, 180, 0);
                    navMeshAgent.updateRotation = false;
                    animationStateController.animator.SetBool("torchHandler", true);
                    playerNavMesh.navMeshAgent.enabled = false;
                    VaseBurningActive = false;
                    animationStateController.isHandlingRunning = true;
                }
            }
            else
            {
                playerController.staticAnimationPlayed = false;
            }
        }
        
    }
   
}
