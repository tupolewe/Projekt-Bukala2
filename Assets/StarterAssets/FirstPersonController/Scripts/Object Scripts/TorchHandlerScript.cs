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
    private int buttonCount = 0;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject HandlePosition;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TorchActiveCheck();
    }

    public void Interact()
    {
        if (torchInRange && torchActive) 
        {
            animationStateController.torchHandle = true;
            buttonCount = 1;
            Player.transform.position = HandlePosition.transform.position;
            Player.transform.rotation = HandlePosition.transform.rotation;
        }
        else if (torchInRange && torchActive && buttonCount > 0) 
        {
            
            buttonCount = 0;
            Player.transform.position = HandlePosition.transform.position;
            Player.transform.rotation = HandlePosition.transform.rotation;
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

}
