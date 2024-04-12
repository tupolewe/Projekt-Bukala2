using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class animationStateController : MonoBehaviour
{

    Animator animator;
    int isWalkingHash;
    int canPushHash;
    public bool torchActive;
    public GameObject Torch;
    public bool canPushD = false;
    public PlayerController playerController;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        canPushHash = Animator.StringToHash("canPush");
       
    }

    // Update is called once per frame
    void Update()
    {
        WalkingAnimation();
        TorchActiveCheck();
        
    }
    
    public void WalkingAnimation ()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        

        bool movementKey = Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.D);
        
         

        if (!canPushD)
        {
            if (movementKey)

            {   
                animator.SetBool("isWalking", true);
                animator.SetBool("canPush", false);

            }

            if (!movementKey)
            {
                animator.SetBool("isWalking", false);
                
            }

            


        }

        if (canPushD)
        {
            if (movementKey)

            {
                animator.SetBool("canPush", true);
                animator.SetBool("isWalking", false);

            }

            if (!movementKey)
            {
                animator.SetBool("canPush", false);
                animator.SetBool("isWalking", false);

            }
            

        
            
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
