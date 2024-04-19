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
    int torchHandlerHash;
    public bool canHandleTorch;
    public bool torchHandle = false;


    public float totalTime = 3f;
    private float currentTime = 3f;
    public bool isTimerRunning = false;
    public bool isHandlingRunning = false;

    public TorchHandlerScript torchHandlerScript;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        canPushHash = Animator.StringToHash("canPush");
        torchHandlerHash = Animator.StringToHash("torchHandler");
    }

    // Update is called once per frame
    void Update()
    {
        WalkingAnimation();
        TorchActiveCheck();
        TorchHandling();
        TorchTimer();
        TorchHandleTimer();


    }
    
    public void WalkingAnimation ()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        

        bool movementKey = Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.D);
        
         

        if (!canPushD)
        {
            if (movementKey && !isTimerRunning && !isHandlingRunning)

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
            if (movementKey && !isTimerRunning && !isHandlingRunning)

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

    void TorchHandling()
    {
        
        bool movementKey = Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.D);
        if (!movementKey && torchHandle && isTimerRunning) 
        {
            animator.SetBool("torchHandler", true);
            
        }
        else if (!isTimerRunning)
        {
            animator.SetBool("torchHandler", false);
        }
        if (torchHandle && isHandlingRunning)
        {
            animator.SetBool("torchHandler", true);

        }



    } 

    void TorchTimer()
    {
        
        if (isTimerRunning)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0) 
            {
                isTimerRunning = false;
                currentTime = 3;
            }
        } 
    }

    void TorchHandleTimer()
    {
        if (isHandlingRunning)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                isHandlingRunning = false;
                currentTime = 3;
                torchHandlerScript.burnCount = 0;
                
            }
        }
    }
}
