using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionChange : MonoBehaviour
{


    private bool canStartTimer = true;
    
    private int changeCount = 0;
    public GameObject Camera1;
    public GameObject Camera2;
    public CameraFollow CameraFollow;
    public PlayerNavMesh PlayerNavMesh;
    public TorchInteraction TorchInteraction;
    public animationStateController animationStateController;
    public PlayerController playerController;
    public VignetteScritp vignette;

    [SerializeField] private float changeDistance; 

    public Transform Position;
    public Transform Player;

    private void Start()
    {
        
    }
    private void Update()
    {
        PositionCheck();

        //Debug.Log(cameraChangeHash);
    }
    public void OnTriggerEnter(Collider collider)
    {
        

        if (collider != null && changeCount < 1 && TorchInteraction.hasTorch)
        {
          CameraFollow.target = null; 

           
            PlayerNavMesh.LevelChange();
            PlayerNavMesh.navMeshAgent.destination = Position.transform.position;
            animationStateController.animator.SetBool("isWalking", true);
            playerController.staticAnimationPlayed = true;
            
            


        }
        if ((collider != null && changeCount < 1 && TorchInteraction.hasTorch ==  false))

        {
            CameraFollow.target = null;
            PlayerNavMesh.LevelChange();
            PlayerNavMesh.navMeshAgent.destination = Position.transform.position;
            animationStateController.animator.SetBool("isWalking", true);
            playerController.staticAnimationPlayed = true;
        }
    }

    void PositionCheck()
    {

        

        if (Vector3.Distance(Player.position, Position.position) < changeDistance && playerController.staticAnimationPlayed && TorchInteraction.hasTorch)
        {
            Debug.Log("dziala pozycja");

            PlayerNavMesh.navMeshAgent.enabled = false;
            animationStateController.animator.SetBool("isWalking", false);
            
            if (canStartTimer)
            {
                StartCoroutine(TimerOff());
                StartCoroutine(TimerOn());
            }
            


        }

        
    }

    IEnumerator TimerOff()
    {
        yield return new WaitForSeconds(1);
        vignette.animator.SetBool("CameraChange", true);
        canStartTimer = false;
        playerController.levelNumber = 1;
    }
          
    IEnumerator TimerOn()
    {
            yield return new WaitForSeconds(2);
            vignette.animator.SetBool("CameraChange", false);
            Camera1.SetActive(false);
            Camera2.SetActive(true);
        playerController.staticAnimationPlayed = false;
        canStartTimer = true;
    }

    
}

