using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DzbanScript : MonoBehaviour, Interactable


{
    
    public GameObject dzbanLight;
    private bool isOn = false;
    public bool torchInRange = false;
    public bool torchActive = true;
    public GameObject Torch;
    public Rigidbody Rigidbody;
    private int pushCount = 0;
    public animationStateController animationStateController;
    public GameObject Player;
    public GameObject PushingPosition;



    // Start is called before the first frame update
    void Start()
    {
        
        dzbanLight.SetActive(false);
        Rigidbody.isKinematic = true;
    }
    void Update()
    {
        TorchActiveCheck();
        Debug.Log(isOn);
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
        }
        else if (isOn && !torchActive && pushCount == 0)
        {

            
            Rigidbody.isKinematic = false;
            pushCount = 1;
            animationStateController.canPushD = true;
            Player.transform.position = PushingPosition.transform.position;
        }
        else if (isOn && !torchActive && pushCount > 0)
        {
            
            Rigidbody.isKinematic = true;
            pushCount = 0;
            animationStateController.canPushD = false;
            

            
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
   
}
