using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchInteraction : MonoBehaviour
{
    public GameObject Torch;
    [SerializeField] private bool torchActive = true;

    public animationStateController animationStateController;

    public void Update()
    {
        TorchFiring(); 
    }

    private void TorchFiring () 
    
    {
      if (Input.GetKeyDown(KeyCode.F) && !animationStateController.canPushD)


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
