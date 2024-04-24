using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.AI;

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




    // Start is called before the first frame update
    void Start()
    {
        
        VaseLight.SetActive(false);
       
        
    }
    void Update()
    {
        TorchActiveCheck();
        //BurnCount();
        
        
       
    }

    void UpdateLight()
    {
        VaseLight.SetActive(true);
        isOn = true; 
         
    }

        


  public void Interact()
    {
        if (torchInRange == true && !isOn && torchActive && vaseBurnPosition.burnPositionNumber > 0)
        {
            UpdateLight();
            animationStateController.torchHandle = true;
            burnCount = 1;
            animationStateController.isTimerRunning = true;
            playerNavMesh.isHandlingTriggered = true;

            if (vaseBurnPosition.burnPositionNumber == 1)
            {
                Debug.Log("asasasas");
                animationStateController.isHandlingRunning = true;
                //playerNavMesh.navMeshAgent.destination = BurnPosition1.transform.position;
                navMeshAgent.updateRotation = false;
                Player.transform.rotation = Quaternion.Euler(0, -360, 0);
            }

            else if (vaseBurnPosition.burnPositionNumber == 2)
            {

                Debug.Log("asasasas");
                animationStateController.isHandlingRunning = true;
                //playerNavMesh.navMeshAgent.destination = BurnPosition2.transform.position;
                Player.transform.rotation = Quaternion.Euler(0, 100, 0);
            }
            else if (vaseBurnPosition.burnPositionNumber == 3)
            {

                Debug.Log("asasasas");
                animationStateController.isHandlingRunning = true;
                //playerNavMesh.navMeshAgent.destination = BurnPosition3.transform.position;
                Player.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else if (vaseBurnPosition.burnPositionNumber == 4)
            {

                Debug.Log("asasasas");
                animationStateController.isHandlingRunning = true;
                //playerNavMesh.navMeshAgent.destination = BurnPosition4.transform.position;
                navMeshAgent.updateRotation = false;
                Player.transform.rotation = Quaternion.Euler(0, 180, 0);
            }

            



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
   
}
