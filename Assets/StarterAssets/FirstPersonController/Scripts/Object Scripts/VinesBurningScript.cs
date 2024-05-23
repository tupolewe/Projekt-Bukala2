using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class VinesBurningScript : MonoBehaviour, Interactable
{
    public animationStateController animationStateController;
    public PlayerNavMesh playerNavMesh;
    public PlayerController controller;
    public TorchInteraction torchInteraction;
    public RayCastInteraction rayCastInteraction;

    public float rotationSpeed;

    public GameObject Torch;
    public GameObject TorchLight;


    public Transform LeftHand;
    public Transform BurningPosition;
    public Transform Player;
    public Transform BurningPoint;

    public bool vinesBurningActive;
    public bool torchActive;
    public bool hasTorch;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TorchActiveCheck();
        VinesBurning();
    }


    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("TorchTrigger") && animationStateController.isHandlingRunning)
            
        {
            Debug.Log("palenie");
            Destroy(gameObject);
        }
    }

    public void Interact()
    {
        if (torchActive)
        {
            vinesBurningActive = true;
            Debug.Log("dziala");
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

        if (Torch.transform.parent == LeftHand)
        {
            hasTorch = true;

        }
    }

    public void VinesBurning()
    {
        if (vinesBurningActive)
        {
            playerNavMesh.navMeshAgent.destination = BurningPosition.transform.position;
            playerNavMesh.VinesBurning();
            controller.staticAnimationPlayed = true;

            if (Vector3.Distance(Player.position, BurningPosition.position) > 0.8f)
            {
                Vector3 direction = BurningPosition.position - Player.transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                Player.transform.rotation = Quaternion.Lerp(Player.transform.rotation, targetRotation, 5f * Time.deltaTime);
                float distance = Vector3.Distance(Player.transform.transform.position, BurningPosition.transform.position);
                playerNavMesh.navMeshAgent.destination = BurningPosition.transform.position;
                animationStateController.animator.SetBool("isWalking", true);

            }

            if (Vector3.Distance(Player.position, BurningPosition.position) < 0.8f)
            {
                // Calculate the direction from the player to the fireplace
                Vector3 fireDirection = BurningPoint.position - Player.transform.position;

                // Normalize fireDirection if needed
                fireDirection.Normalize();

                // Calculate the angle between the player's forward direction and fireDirection
                float angle = Vector3.Angle(Player.transform.forward, fireDirection);

                // Define a threshold angle to determine if the player is facing the right direction
                float thresholdAngle = 10f; // Adjust as needed

                //Debug.Log(angle);
                animationStateController.animator.SetBool("isWalking", false);

                Debug.Log(angle);

                rotationSpeed = 120f;

                if (angle <= thresholdAngle)
                {
                    animationStateController.animator.SetBool("torchHandler", true);
                    playerNavMesh.navMeshAgent.enabled = false;
                    Player.transform.LookAt(BurningPoint);
                    vinesBurningActive = false;
                    animationStateController.animator.SetBool("isWalking", false);
                    animationStateController.isHandlingRunning = true;
                }

                else
                {
                    // Player is not facing the right direction, rotate the player towards the fireplace
                    
                    animationStateController.animator.SetBool("isWalking", true);

                    Quaternion firetargetRotation = Quaternion.LookRotation(fireDirection);
                    Player.transform.rotation = Quaternion.RotateTowards(Player.transform.rotation, firetargetRotation, rotationSpeed * Time.deltaTime);
                }
            }
        }

        
    }
}
