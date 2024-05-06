using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class TorchHandlerScript : MonoBehaviour, Interactable
{
    public bool torchInRange = false;
    public bool torchActive;
    public bool torchHandled = false;
   
    public animationStateController animationStateController;
    public PlayerNavMesh playerNavMesh;
    public PlayerController controller;

    public GameObject TorchLight;
    public GameObject Torch;
    public GameObject HandlePosition;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject TorchHandlePosition;
    [SerializeField] private GameObject TorchPosition;


    public Transform PlayerTransform;
    public Transform HandleTransform;
    public Transform TorchHandlingPosition;


    public int burnCount;

    public bool torchHandlingActive;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TorchActiveCheck();
        NavMeshDestination();

        

    }

    public void Interact()

    {
        Debug.Log("torch handling1");
        if (torchActive) 
        {
            
             torchHandlingActive = true;
            
            

        }
        
        
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Torch"))
        {
            torchInRange = true;
            animationStateController.canHandleTorch = true;
        }
        else
        {
            torchInRange = false;
            animationStateController.canHandleTorch = false;
        }


    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Torch"))
        {
            torchInRange = false;
            animationStateController.canHandleTorch = false;
            animationStateController.torchHandle = false;
        }
    }

    public void TorchActiveCheck()
    {
        if (TorchLight.activeInHierarchy == true)
        {
            torchActive = true;
        }
        else if (TorchLight.activeInHierarchy == false)
        {
            torchActive = false;
        }
    }

    void BurnCount()
    {
        if (burnCount == 0)
        {
            animationStateController.torchHandle = false;
            
        }
    }

    void NavMeshDestination()
    {
        if (torchHandlingActive)
        {
            playerNavMesh.navMeshAgent.destination = HandlePosition.transform.position;
            playerNavMesh.WallHandling();
            controller.staticAnimationPlayed = true;

            if (Vector3.Distance(PlayerTransform.position, HandleTransform.position) > 0.25f)
            {
                Vector3 direction = HandleTransform.position - Player.transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                Player.transform.rotation = Quaternion.Lerp(Player.transform.rotation, targetRotation, 5f * Time.deltaTime);
                float distance = Vector3.Distance(Player.transform.transform.position, HandleTransform.transform.position);
                playerNavMesh.navMeshAgent.destination = HandleTransform.transform.position;
                animationStateController.animator.SetBool("isWalking", true);

            }

                if (Vector3.Distance(PlayerTransform.position, HandleTransform.position) < 0.25f)
            {
                // Calculate the direction from the player to the fireplace
                Vector3 fireDirection = TorchHandlingPosition.position - Player.transform.position;

                // Normalize fireDirection if needed
                fireDirection.Normalize();

                // Calculate the angle between the player's forward direction and fireDirection
                float angle = Vector3.Angle(Player.transform.forward, fireDirection);

                // Define a threshold angle to determine if the player is facing the right direction
                float thresholdAngle = 24f; // Adjust as needed

                Debug.Log(angle);
                animationStateController.animator.SetBool("isWalking", false);

                if (angle <= thresholdAngle) 
                {
                    animationStateController.animator.SetBool("torchHandler", true);
                    playerNavMesh.navMeshAgent.enabled = false;
                    torchHandlingActive = false;
                    animationStateController.isHandlingRunning = true;
                    animationStateController.animator.SetBool("isWalking", false);
                    controller.speed = 3;
                    Player.transform.rotation = Quaternion.Euler(0, 270, 0);
                }

                else
                {
                    // Player is not facing the right direction, rotate the player towards the fireplace
                    Quaternion firetargetRotation = Quaternion.LookRotation(fireDirection);
                    Player.transform.rotation = Quaternion.Lerp(Player.transform.rotation, firetargetRotation, 3.5f * Time.deltaTime);
                    animationStateController.animator.SetBool("isWalking", true);
                }



            }
        }
        
    }

    

}
