using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionChange : MonoBehaviour, IDataPersistence
{

    public int level;
    private bool canStartTimer = true;
    
    public int changeCount = 0;

    public GameObject torch; 
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Level2Walls;
    public CameraFollow CameraFollow;
    public CameraFollow CameraFollow2;
    public PlayerNavMesh PlayerNavMesh;
    public TorchInteraction TorchInteraction;
    public animationStateController animationStateController;
    public PlayerController playerController;
    public VignetteScritp vignette;

    [SerializeField] private float changeDistance; 

    public Transform Position1;
    public Transform Position2;
    public Transform Player;

    private void Start()
    {
        level = 0;
    }
    private void Update()
    {
        PositionCheck();

        //Debug.Log(cameraChangeHash);
    }
    public void OnTriggerEnter(Collider collider)
    {
        

        if (collider != torch && level == 0)
        {
            CameraFollow.target = null; 

           
            PlayerNavMesh.LevelChange();
            PlayerNavMesh.navMeshAgent.destination = Position1.transform.position;
            animationStateController.animator.SetBool("isWalking", true);
            playerController.staticAnimationPlayed = true;
            changeCount = 1; 
            


        }
        //else if ((collider != torch && changeCount < 1 && TorchInteraction.hasTorch ==  false))

        //{
            //CameraFollow.target = null;
            //PlayerNavMesh.LevelChange();
            //PlayerNavMesh.navMeshAgent.destination = Position1.transform.position;
            //animationStateController.animator.SetBool("isWalking", true);
            //playerController.staticAnimationPlayed = true;
            
        //}

        if ((collider != torch && level == 1))
        {

            Debug.Log("level2");
            CameraFollow2.target = null;


            PlayerNavMesh.LevelChange();
            PlayerNavMesh.navMeshAgent.destination = Position2.transform.position;
            animationStateController.animator.SetBool("isWalking", true);
            playerController.staticAnimationPlayed = true;
            changeCount = 0;
        }


    }

    void PositionCheck()
    {

        //Debug.Log(Vector3.Distance(Player.position, Position.position)); 

        if (Vector3.Distance(Player.position, Position1.position) < changeDistance && playerController.staticAnimationPlayed && level == 0)
        {
            //Debug.Log("dziala pozycja");

            PlayerNavMesh.navMeshAgent.enabled = false;
            animationStateController.animator.SetBool("isWalking", false);
            level = 1;
            
            if (canStartTimer)
            {
                StartCoroutine(TimerOff1());
                StartCoroutine(TimerOn1());
            }

            

        }
        else if (Vector3.Distance(Player.position, Position2.position) < changeDistance && playerController.staticAnimationPlayed && level == 1)
        {
            PlayerNavMesh.navMeshAgent.enabled = false;
            animationStateController.animator.SetBool("isWalking", false);
            level = 0;

            if (canStartTimer)
            {
                StartCoroutine(TimerOff2());
                StartCoroutine(TimerOn2());
            }

        }


    }

    IEnumerator TimerOff1()
    {
        yield return new WaitForSeconds(1);
        vignette.animator.SetBool("CameraChange", true);
        canStartTimer = false;
        playerController.levelNumber = 1;
        
    }
          
    IEnumerator TimerOn1()
    {
            yield return new WaitForSeconds(2);
            vignette.animator.SetBool("CameraChange", false);
            Camera1.SetActive(false);
            Camera2.SetActive(true);
        playerController.staticAnimationPlayed = false;
        canStartTimer = true;
        CameraFollow2.target = Player.transform;
        Level2Walls.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }

    IEnumerator TimerOff2()
    {
        yield return new WaitForSeconds(1);
        vignette.animator.SetBool("CameraChange", true);
        canStartTimer = false;
        playerController.levelNumber = 0;

    }

    IEnumerator TimerOn2()
    {
        yield return new WaitForSeconds(2);
        vignette.animator.SetBool("CameraChange", false);
        Camera1.SetActive(true);
        Camera2.SetActive(false);
        playerController.staticAnimationPlayed = false;
        canStartTimer = true;
        CameraFollow.target = Player.transform;
        Level2Walls.gameObject.SetActive(true);
    }



    public void SaveData(ref GameData data)
    {
        
    }

   public void LoadData(GameData data)
    {
            
    }
}

