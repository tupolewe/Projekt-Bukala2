using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class DzbanScript : MonoBehaviour, Interactable


{
    
    public GameObject dzbanLight;
    private bool isOn = false;
    public bool torchInRange = false;
    public bool torchActive = true;
    public GameObject Torch;
    
    private bool canPushD;
    public animationStateController animationStateController;
    public GameObject Player;
    public GameObject PushingPosition;
    public GameObject dzban;
    public PlayerController playerController;
    public int burnCount = 0;
    public Rigidbody playerRb;
    



    // Start is called before the first frame update
    void Start()
    {
        
        dzbanLight.SetActive(false);
       
        
    }
    void Update()
    {
        TorchActiveCheck();
        BurnCount();   
        
       
    }

    void UpdateLight()
    {
        dzbanLight.SetActive(true);
        isOn = true; 
         
    }

        


  public void Interact()
    {
        if (torchInRange == true && !isOn && torchActive)
        {
            UpdateLight();
            animationStateController.torchHandle = true;
            burnCount = 1;
           

        }
        else if (isOn && !torchActive && !canPushD)
        {


            playerController.speed = 2;
            canPushD = true;
            animationStateController.canPushD = true;
            
            dzban.transform.position = PushingPosition.transform.position;
            dzban.transform.SetParent(Player.transform, true);
        }
        else if (isOn && !torchActive && canPushD)
        {
            
            playerController.speed = 4;
            animationStateController.canPushD = false;
            canPushD = false;
            dzban.transform.parent = null;

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
            Debug.Log(burnCount);
        }
    }
   
}
