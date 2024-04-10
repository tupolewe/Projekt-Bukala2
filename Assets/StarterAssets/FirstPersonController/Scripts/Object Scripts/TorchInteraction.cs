using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchInteraction : MonoBehaviour
{
    public GameObject Torch;
    [SerializeField] private bool torchActive = true;

    public void Update()
    {
        TorchFiring(); 
    }

    private void TorchFiring () 
    
    {
      if (Input.GetKeyDown(KeyCode.F))


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
