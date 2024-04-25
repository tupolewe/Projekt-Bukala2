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

           if(Vector3.Distance(PlayerTransform.position, HandleTransform.position) < 0.25f)
            {
                animationStateController.animator.SetBool("torchHandler", true);
                playerNavMesh.navMeshAgent.enabled = false;
                torchHandlingActive = false;
                animationStateController.isHandlingRunning = true;
                controller.staticAnimationPlayed = true;
            }
        }
        
    }

    

}
