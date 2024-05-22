using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchInteraction : MonoBehaviour
{
    public GameObject Torch;
    [SerializeField] private bool torchActive = true;
     MeshSockets sockets;
    public bool hasTorch = true;
    public animationStateController animationStateController;

    public void Start()
    {

        

    }
    public void Update()
    {
        TorchFiring(); 
    }

    private void TorchFiring () 
    
    {
      if (Input.GetKeyDown(KeyCode.F) && !animationStateController.canPushD && hasTorch)


        {
            if (torchActive)
            {
                Torch.SetActive(false);
                torchActive = false;
            }

            else if (!torchActive)
            {
                Torch.SetActive(true);
                torchActive = true;
            }
            
        }
    } 
        
    
}
