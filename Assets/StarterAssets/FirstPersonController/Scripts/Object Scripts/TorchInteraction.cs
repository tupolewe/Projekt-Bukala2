using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchInteraction : MonoBehaviour
{
    public GameObject Torch;
    [SerializeField] private bool torchActive = true;
     MeshSockets sockets;

    public animationStateController animationStateController;

    public void Start()
    {
        sockets = GetComponent<MeshSockets>();
        
        sockets.Attach(Torch.transform, MeshSockets.SocketId.Hand);
    }
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
