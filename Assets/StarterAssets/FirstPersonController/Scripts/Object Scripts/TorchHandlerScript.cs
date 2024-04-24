using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class TorchHandlerScript : MonoBehaviour, Interactable
{
    public bool torchInRange = false;
    public bool torchActive;
    public bool torchHandled = false;
   
    public animationStateController animationStateController;
    public PlayerNavMesh playerNavMesh;

    public GameObject TorchLight;
    public GameObject Torch;
    public GameObject HandlePosition;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject TorchHandlePosition;
    [SerializeField] private GameObject TorchPosition;

    public int burnCount;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
       
        
    }

    public void Interact()
    {
        
        
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

}
