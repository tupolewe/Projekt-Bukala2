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
    public float rotationSpeed = 10000f;




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

        //Debug.Log(rotatedToPosition);
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
            VaseSource.loop = false;
            VaseSource.clip = VaseScratchClip;

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

    void NavMeshDestination()
    {
        

        if (VaseBurningActive == true)
        {
            playerController.staticAnimationPlayed = true;
            playerNavMesh.VaseBurning();

            

            if (vaseBurnPosition.burnPositionNumber == 1 && !rotatedToPosition)
            {
                
                playerNavMesh.navMeshAgent.destination = BurnTransform1.transform.position;
                Vector3 direction = BurnTransform1.position - Player.transform.position;
                
                
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                
                
                Player.transform.rotation = Quaternion.Lerp(Player.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                float distance = Vector3.Distance(Player.transform.transform.position, BurnPosition1.transform.position);
                animationStateController.animator.SetBool("isWalking", true);
                Debug.Log("kreci sie");
                if (distance < 1.7f)
                {


                    rotatedToPosition = true;
                    Debug.Log("inPosition");
                    //animationStateController.animator.SetBool("isWalking", false);

                }
            }
            if (vaseBurnPosition.burnPositionNumber == 2 && !rotatedToPosition)
            {
                Vector3 direction = BurnTransform2.position - Player.transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                Player.transform.rotation = Quaternion.Lerp(Player.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                float distance = Vector3.Distance(Player.transform.transform.position, BurnPosition2.transform.position);
                playerNavMesh.navMeshAgent.destination = BurnPosition2.transform.position;
                animationStateController.animator.SetBool("isWalking", true);
                Debug.Log("kreci sie");
                if (distance < 1.7f)
                {
                    rotatedToPosition = true;
                    Debug.Log("inPosition");
                    //animationStateController.animator.SetBool("isWalking", false);
                }
            }
            if (vaseBurnPosition.burnPositionNumber == 3 && !rotatedToPosition)
            {
                Vector3 direction = BurnTransform3.position - Player.transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                Player.transform.rotation = Quaternion.Lerp(Player.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                float distance = Vector3.Distance(Player.transform.transform.position, BurnPosition3.transform.position);
                playerNavMesh.navMeshAgent.destination = BurnPosition3.transform.position;
                animationStateController.animator.SetBool("isWalking", true);
                Debug.Log("kreci sie");
                if (distance < 1.7f)
                {
                    rotatedToPosition = true;
                    Debug.Log("inPosition");
                    //animationStateController.animator.SetBool("isWalking", false);
                }
            }
            if (vaseBurnPosition.burnPositionNumber == 4 && !rotatedToPosition)
            {
                Vector3 direction = BurnTransform4.position - Player.transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                Player.transform.rotation = Quaternion.Lerp(Player.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                playerNavMesh.navMeshAgent.destination = BurnPosition4.transform.position;
                float distance = Vector3.Distance(Player.transform.transform.position, BurnPosition4.transform.position);
                animationStateController.animator.SetBool("isWalking", true);
                Debug.Log("kreci sie");
                if (distance < 1.7f)
                {
                    rotatedToPosition = true;
                    Debug.Log("inPosition");
                    //animationStateController.animator.SetBool("isWalking", false);
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
        if (vaseBurnPosition.burnPositionNumber == 1 && rotatedToPosition)
        {
            // Calculate the direction from the player to the fireplace
            Vector3 fireDirection = Fireplace.position - Player.transform.position;

            // Normalize fireDirection if needed
            fireDirection.Normalize();

            // Calculate the angle between the player's forward direction and fireDirection
            float angle = Vector3.Angle(Player.transform.forward, fireDirection);

            // Define a threshold angle to determine if the player is facing the right direction
            float thresholdAngle = 15f; // Adjust as needed

            Debug.Log(angle);
            animationStateController.animator.SetBool("isWalking", false);



            // Check if the angle is within the threshold
            if (angle <= thresholdAngle)
            {

                Player.transform.rotation = Quaternion.Euler(0, -360, 0);
                navMeshAgent.updateRotation = false;
                animationStateController.animator.SetBool("torchHandler", true);
                playerNavMesh.navMeshAgent.enabled = false;
                VaseBurningActive = false;
                animationStateController.isHandlingRunning = true;
                UpdateLight();
                rotatedToPosition = false;
                
            }
            else
            {
                // Player is not facing the right direction, rotate the player towards the fireplace
                //Quaternion firetargetRotation = Quaternion.LookRotation(Fireplace.position - Player.transform.position);
                //Player.transform.rotation = Quaternion.RotateTowards(Player.transform.rotation, firetargetRotation, rotationSpeed * Time.deltaTime);
                Player.transform.LookAt(Fireplace);

            }
        }
        
        if (vaseBurnPosition.burnPositionNumber == 2 && rotatedToPosition)
        {
            // Calculate the direction from the player to the fireplace
            Vector3 fireDirection = Fireplace.position - Player.transform.position;

            // Normalize fireDirection if needed
            fireDirection.Normalize();

            // Calculate the angle between the player's forward direction and fireDirection
            float angle = Vector3.Angle(Player.transform.forward, fireDirection);

            // Define a threshold angle to determine if the player is facing the right direction
            float thresholdAngle = 15f; // Adjust as needed

            Debug.Log(angle);
            animationStateController.animator.SetBool("isWalking", false);

            // Check if the angle is within the threshold
            if (angle <= thresholdAngle)
            {

                Player.transform.rotation = Quaternion.Euler(0, 100, 0);
                navMeshAgent.updateRotation = false;
                animationStateController.animator.SetBool("torchHandler", true);
                playerNavMesh.navMeshAgent.enabled = false;
                VaseBurningActive = false;
                animationStateController.isHandlingRunning = true;
                UpdateLight();
                rotatedToPosition = false;
                
            }
            else
            {
                // Player is not facing the right direction, rotate the player towards the fireplace
                //Quaternion firetargetRotation = Quaternion.LookRotation(Fireplace.position - Player.transform.position);
                //Player.transform.rotation = Quaternion.RotateTowards(Player.transform.rotation, firetargetRotation, rotationSpeed * Time.deltaTime);
                Player.transform.LookAt(Fireplace);
            }
        }
        

        if (vaseBurnPosition.burnPositionNumber == 3 && rotatedToPosition)
        {
            // Calculate the direction from the player to the fireplace
            Vector3 fireDirection = Fireplace.position - Player.transform.position;

            // Normalize fireDirection if needed
            fireDirection.Normalize();

            // Calculate the angle between the player's forward direction and fireDirection
            float angle = Vector3.Angle(Player.transform.forward, fireDirection);

            // Define a threshold angle to determine if the player is facing the right direction
            float thresholdAngle = 15f; // Adjust as needed

            Debug.Log(angle);
            animationStateController.animator.SetBool("isWalking", false);

            // Check if the angle is within the threshold
            if (angle <= thresholdAngle)
            {

                Player.transform.rotation = Quaternion.Euler(0, -90, 0);
                navMeshAgent.updateRotation = false;
                animationStateController.animator.SetBool("torchHandler", true);
                playerNavMesh.navMeshAgent.enabled = false;
                VaseBurningActive = false;
                animationStateController.isHandlingRunning = true;
                UpdateLight();
                rotatedToPosition = false;
                
            }
            else
            {
                // Player is not facing the right direction, rotate the player towards the fireplace
                //Quaternion firetargetRotation = Quaternion.LookRotation(Fireplace.position - Player.transform.position);
                //Player.transform.rotation = Quaternion.RotateTowards(Player.transform.rotation, firetargetRotation, rotationSpeed * Time.deltaTime);
                Player.transform.LookAt(Fireplace);
            }
        }
            

        if (vaseBurnPosition.burnPositionNumber == 4 && rotatedToPosition)


        {
            // Calculate the direction from the player to the fireplace
            Vector3 fireDirection = Fireplace.position - Player.transform.position;

            // Normalize fireDirection if needed
            //fireDirection.Normalize();

            // Calculate the angle between the player's forward direction and fireDirection
            float angle = Vector3.Angle(Player.transform.forward, fireDirection);

            // Define a threshold angle to determine if the player is facing the right direction
            float thresholdAngle = 10f; // Adjust as needed

            Debug.Log(angle);
            animationStateController.animator.SetBool("isWalking", false);

            // Check if the angle is within the threshold
            if (angle <= thresholdAngle)
            {

                Player.transform.rotation = Quaternion.Euler(0, 180, 0);
                navMeshAgent.updateRotation = false;
                animationStateController.animator.SetBool("torchHandler", true);
                playerNavMesh.navMeshAgent.enabled = false;
                VaseBurningActive = false;
                animationStateController.isHandlingRunning = true;
                UpdateLight();
                rotatedToPosition = false;
                
            }
            else
            {
                // Player is not facing the right direction, rotate the player towards the fireplace
                //Quaternion firetargetRotation = Quaternion.LookRotation(Fireplace.position - Player.transform.position);
                //Player.transform.rotation = Quaternion.RotateTowards(Player.transform.rotation, firetargetRotation, rotationSpeed * Time.deltaTime);
                Player.transform.LookAt(Fireplace);
            }


        }
    }
}
