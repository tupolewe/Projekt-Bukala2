using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class TorchHandlerScript : MonoBehaviour, Interactable
{
    public bool torchInRange = false;
    public bool torchActive;
    public GameObject Torch;
    public animationStateController animationStateController;
    public PlayerNavMesh playerNavMesh;
    

    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject HandlePosition;

    public int burnCount;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TorchActiveCheck();
        //BurnCount();
       // Debug.Log(burnCount);
    }

    public void Interact()
    {
        if (torchInRange && torchActive) 
        {
            playerNavMesh.isHandlingTriggered = true;
            animationStateController.isHandlingRunning = true;
            animationStateController.torchHandle = true;
            burnCount = 1;
            
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
        if (burnCount == 0)
        {
            animationStateController.torchHandle = false;
            
        }
    }

}
