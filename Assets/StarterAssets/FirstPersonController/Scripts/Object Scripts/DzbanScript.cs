using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.XR;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class DzbanScript : MonoBehaviour, Interactable


{
    public animationStateController animationStateController;
    public PlayerController playerController;
    public VaseBurnPosition vaseBurnPosition;
    public PlayerNavMesh playerNavMesh;
    public RayCastInteraction rayCastInteraction;
    
    public TorchInteraction torchInteraction;
   
    public bool torchInRange = false;
    public bool torchActive = true;
    private bool canPushD;
    public bool isOn = false;
    public bool playerFarEnough;
    public bool rotatedToPosition = false;
    

    public AudioClip VaseScratchClip;
    public AudioSource VaseSource;



    public int burnCount = 0;
    public Rigidbody playerRb;

    public GameObject TorchLight;
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
    public Transform Fireplace;
    public Transform PlayerTransform;

    public bool VaseBurningActive;
    public float distanceToPosition = 3;
    public float rotationSpeed;




    // Start is called before the first frame update
    void Start()
    {
        
        VaseLight.SetActive(false);
        VaseSource.loop = true;
        VaseSource.clip = VaseScratchClip;
        
    }
    void Update()
    {
        TorchActiveCheck();
        NavMeshDestination();
        BurningDistanceCheck();
        DistanceCheck();

        //Debug.Log(isOn);
       
    }

    void UpdateLight()
    {
        VaseLight.SetActive(true);
        isOn = true; 
         
    }

        


  public void Interact()
    {
        
       if (torchActive && !isOn && vaseBurnPosition.burnPositionNumber > 0 && torchInteraction.hasTorch)
            {
                VaseBurningActive = true;
                //UpdateLight();
            
            }
       else if (isOn && !torchActive && !canPushD)
        {


            VasePush();

        }
        else if (isOn && !torchActive && canPushD)
        {
            
            BackToWalking();

        }

        

        
        
       
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            torchInRange = true;
        }
        else
        {
            torchInRange = false;
        }

        if (collider != TorchLight && animationStateController.isHandlingRunning)
        {
            Debug.Log("dziala");
            UpdateLight();
            Debug.Log(collider);
        }
       
    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            torchInRange = false;
            burnCount = 0;
            
        }
    }

    public void TorchActiveCheck ()
    {

        if (torchInteraction.hasTorch)
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
        if (torchInteraction.hasTorch == false)
        {
            torchActive = false;
        }
        

    }

    void NavMeshDestination()
    {


        if (VaseBurningActive == true)
        {
            playerController.staticAnimationPlayed = true;
            playerNavMesh.VaseBurning();

            Transform currentBurnPosition = null;
            Transform currentBurnTransform = null;

            switch (vaseBurnPosition.burnPositionNumber)
            {
                case 1:
                    currentBurnPosition = BurnPosition1.transform;
                    currentBurnTransform = BurnTransform1;

                    break;
                case 2:
                    currentBurnPosition = BurnPosition2.transform;
                    currentBurnTransform = BurnTransform2;
                    break;
                case 3:
                    currentBurnPosition = BurnPosition3.transform;
                    currentBurnTransform = BurnTransform3;
                    break;
                case 4:
                    currentBurnPosition = BurnPosition4.transform;
                    currentBurnTransform = BurnTransform4;
                    break;
            }



            if (!rotatedToPosition)
            {
                playerNavMesh.navMeshAgent.destination = currentBurnTransform.position;
                Vector3 direction = currentBurnTransform.position - Player.transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                Player.transform.rotation = Quaternion.Lerp(Player.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                float distance = Vector3.Distance(Player.transform.transform.position, currentBurnPosition.position);
                animationStateController.animator.SetBool("isWalking", true);
                
                if (distance < 1.7f)
                {
                    rotatedToPosition = true;
                    

                }
            }
        }

    }

    void DistanceCheck()
    {
        if (rayCastInteraction.currentHitDistance > 0.5f && playerController.staticAnimationPlayed == false)
        {
            playerFarEnough = true;
            //Debug.Log("daleko");
        }
        else if (rayCastInteraction.currentHitDistance < 0.5f && playerController.staticAnimationPlayed == false)
        {
            playerFarEnough = false;
            //Debug.Log("blisko");

        }
    }
    void BurningDistanceCheck()
    {
        if (rotatedToPosition)
        {
            // Calculate the direction from the player to the fireplace
            Vector3 fireDirection = Fireplace.position - Player.transform.position;

            // Normalize fireDirection if needed
            fireDirection.Normalize();

            // Calculate the angle between the player's forward direction and fireDirection
            float angle = Vector3.Angle(Player.transform.forward, fireDirection);

            // Define a threshold angle to determine if the player is facing the right direction
            float thresholdAngle = 5f; // Adjust as needed

            Debug.Log(angle);
            //animationStateController.animator.SetBool("isWalking", false);

            rotationSpeed = 120f;

            // Check if the angle is within the threshold
            if (angle <= thresholdAngle)
            {

                
                navMeshAgent.updateRotation = false;
                animationStateController.animator.SetBool("torchHandler", true);
                animationStateController.animator.SetBool("isWalking", false);
                playerNavMesh.navMeshAgent.enabled = false;
                VaseBurningActive = false;
                animationStateController.isHandlingRunning = true;
                rotatedToPosition = false;
                rotationSpeed = 2;


            }
            else
            {
                // Player is not facing the right direction, rotate the player towards the fireplace
                Quaternion firetargetRotation = Quaternion.LookRotation(Fireplace.position - Player.transform.position);
                Player.transform.rotation = Quaternion.RotateTowards(Player.transform.rotation, firetargetRotation, rotationSpeed * Time.deltaTime);
                //Player.transform.LookAt(Fireplace);

            }
        }
        
        
    }


    void VasePush()
    {
        playerController.speed = 2;
        canPushD = true;
        animationStateController.canPushD = true;
        playerController.turnSpeed = 80;
        Vase.transform.position = PushingPosition.transform.position;
        Vase.transform.SetParent(Player.transform, true);
    }

    void BackToWalking()
    {
        playerController.speed = 4;
        animationStateController.canPushD = false;
        canPushD = false;
        Vase.transform.parent = null;
        playerController.turnSpeed = 340;
        VaseSource.loop = false;
        VaseSource.clip = VaseScratchClip;
    }
}
