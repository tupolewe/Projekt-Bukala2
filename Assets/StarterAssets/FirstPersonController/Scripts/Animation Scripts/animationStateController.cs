using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
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
        PushingAnimation();
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
            }

            if (!movementKey)
            {
                animator.SetBool("isWalking", false);
            }

        
        }

    }

    public void PushingAnimation ()
    {
        bool canPush = animator.GetBool(canPushHash) && canPushD;
        
        bool movementKey = Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.D);

        

        if (!torchActive && canPushD) 
        {

            if (movementKey)
            {
                animator.SetBool("canPush", true);
            }

            if (!movementKey)
            {
                animator.SetBool("canPush", false);
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
