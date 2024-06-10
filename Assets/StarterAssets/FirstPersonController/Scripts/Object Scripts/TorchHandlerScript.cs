using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.EnhancedTouch;

public class TorchHandlerScript : MonoBehaviour, Interactable
{
    public bool torchInRange = false;
    public bool torchActive;
    public bool torchHandled = false;
    public bool hasTorch;
    public bool playerFarEnough;

    public animationStateController animationStateController;
    public PlayerNavMesh playerNavMesh;
    public PlayerController controller;
    public TorchInteraction torchInteraction;
    public RayCastInteraction rayCastInteraction;

    public GameObject TorchLight;
    public GameObject Torch;
    public GameObject HandlePosition;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject TorchHandlePosition;
    [SerializeField] private GameObject TorchPosition;


    public Transform PlayerTransform;
    public Transform HandleTransform;
    public Transform TorchHandlingPosition;
    public Transform TorchHandler;
    public Transform LeftHand;

    public float rotationSpeed;


    public int burnCount;

    public bool torchHandlingActive;
    public int torchHandleCount = 0;

    public TextMeshProUGUI actionHint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TorchActiveCheck();
        
        
        NavMeshDestination();


        


        DistanceCheck();



        

    }

    public void Interact()

    {
        
          if (torchActive && playerFarEnough) 
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

        if (collider.CompareTag("LeftHand") && animationStateController.isHandlingRunning && torchInteraction.hasTorch && torchHandleCount == 0)
        {
            Torch.transform.SetParent(TorchHandler, true);

            if (Torch.transform.parent == TorchHandler)
            {
                Debug.Log("dziala");
                Torch.transform.localPosition = new Vector3(-17.322f, 43.7f, -1.382f);
                Torch.transform.localRotation = Quaternion.Euler(34.42f, -90.5f, -268.367f);
                torchHandled = true;
                torchInteraction.hasTorch = false;
                torchHandleCount = 1;
            }
        }
        else if (collider.CompareTag("LeftHand") && animationStateController.isHandlingRunning && torchInteraction.hasTorch == false && torchHandleCount == 1)
        {
            Torch.transform.SetParent(LeftHand, true);

            if (Torch.transform.parent == LeftHand)
            {
                Debug.Log("dziala2");
                Torch.transform.localPosition = new Vector3(27.833f, 29.817f, 13.973f);
                Torch.transform.localRotation = Quaternion.Euler(-147.238f, 53.55f, -83.135f);
                torchHandled = false;
                torchInteraction.hasTorch = true;
                torchHandleCount = 0;
            }
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

        if (Torch.transform.parent == LeftHand)
        {
            hasTorch = true;

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
        
            if (torchInteraction.hasTorch)
            {
                if (!torchHandled && torchHandlingActive)
                {
                    playerNavMesh.navMeshAgent.destination = HandlePosition.transform.position;
                    playerNavMesh.WallHandling();
                    controller.staticAnimationPlayed = true;

                    if (Vector3.Distance(PlayerTransform.position, HandleTransform.position) > 0.8f)
                    {
                        Vector3 direction = HandleTransform.position - Player.transform.position;
                        Quaternion targetRotation = Quaternion.LookRotation(direction);
                        Player.transform.rotation = Quaternion.Lerp(Player.transform.rotation, targetRotation, 5f * Time.deltaTime);
                        float distance = Vector3.Distance(Player.transform.transform.position, HandleTransform.transform.position);
                        playerNavMesh.navMeshAgent.destination = HandleTransform.transform.position;
                        animationStateController.animator.SetBool("isWalking", true);

                    }

                    if (Vector3.Distance(PlayerTransform.position, HandleTransform.position) < 0.8f)
                    {
                        // Calculate the direction from the player to the fireplace
                        Vector3 fireDirection = TorchHandlingPosition.position - Player.transform.position;

                        // Normalize fireDirection if needed
                        fireDirection.Normalize();

                        // Calculate the angle between the player's forward direction and fireDirection
                        float angle = Vector3.Angle(Player.transform.forward, fireDirection);

                        // Define a threshold angle to determine if the player is facing the right direction
                        float thresholdAngle = 19f; // Adjust as needed

                        //Debug.Log(angle);
                        animationStateController.animator.SetBool("isWalking", false);

                        Debug.Log(angle);

                    rotationSpeed = 120f;

                        if (angle <= thresholdAngle)
                        {
                            //Torch.transform.SetParent(TorchHandler, true);

                            animationStateController.animator.SetBool("torchHandler", true);
                            playerNavMesh.navMeshAgent.enabled = false;
                            torchHandlingActive = false;
                            animationStateController.isHandlingRunning = true;
                            animationStateController.animator.SetBool("isWalking", false);
                            controller.speed = 5;
                            //Player.transform.rotation = Quaternion.Euler(0, 180, 0);
                            Player.transform.LookAt(TorchHandlingPosition);

                        if (Torch.transform.parent == TorchHandler)
                            {
                                Debug.Log("dziala");
                                

                            }
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

            if (torchInteraction.hasTorch == false)

            {
                if (torchHandled && torchHandlingActive)
                {
                    playerNavMesh.navMeshAgent.destination = HandlePosition.transform.position;
                    playerNavMesh.WallHandling();
                    controller.staticAnimationPlayed = true;

                    if (Vector3.Distance(PlayerTransform.position, HandleTransform.position) > 0.8f)
                    {
                        Vector3 direction = HandleTransform.position - Player.transform.position;
                        Quaternion targetRotation = Quaternion.LookRotation(direction);
                        Player.transform.rotation = Quaternion.Lerp(Player.transform.rotation, targetRotation, 5f * Time.deltaTime);
                        float distance = Vector3.Distance(Player.transform.transform.position, HandleTransform.transform.position);
                        playerNavMesh.navMeshAgent.destination = HandleTransform.transform.position;
                        animationStateController.animator.SetBool("isWalking", true);

                    }

                    if (Vector3.Distance(PlayerTransform.position, HandleTransform.position) < 0.8f)
                    {
                        // Calculate the direction from the player to the fireplace
                        Vector3 fireDirection = TorchHandlingPosition.position - Player.transform.position;

                        // Normalize fireDirection if needed
                        fireDirection.Normalize();

                        // Calculate the angle between the player's forward direction and fireDirection
                        float angle = Vector3.Angle(Player.transform.forward, fireDirection);

                        // Define a threshold angle to determine if the player is facing the right direction
                        float thresholdAngle = 18.5f; // Adjust as needed

                        //Debug.Log(angle);
                        animationStateController.animator.SetBool("isWalking", false);
                    Debug.Log(angle);

                    rotationSpeed = 90f;

                        if (angle <= thresholdAngle)
                        {
                            

                            animationStateController.animator.SetBool("torchHandler", true);
                            playerNavMesh.navMeshAgent.enabled = false;
                            torchHandlingActive = false;
                            animationStateController.isHandlingRunning = true;
                            animationStateController.animator.SetBool("isWalking", false);
                            controller.speed = 5;
                            Player.transform.LookAt(TorchHandlingPosition);



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

      void DistanceCheck()
    {
        if (rayCastInteraction.currentHitDistance > 0f)
        {
            playerFarEnough = true;
            //Debug.Log("daleko");
        }
        else
        {
            playerFarEnough = false;
        }


        if (rayCastInteraction.currentHitObject.GetComponent("TorchHandlerScript"))
        {
            if (torchInteraction.hasTorch)
            {
                
                    actionHint.text = "Press 'E' to put down the torch";

                
            }
            
            else if (torchInteraction.hasTorch == false)
            {
                actionHint.text = "Press 'E' to grab the torch";


            }
            else
            {
                actionHint.text = string.Empty;
            }
        }
       





    }
    }


    


