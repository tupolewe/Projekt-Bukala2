using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level6Transistion : MonoBehaviour
{

    public bool inPosition;
    public GameObject wall;
    public Transform Player;
    public Transform Position;

    public GameObject Camera3;
    public GameObject Camera5;
    public PlayerNavMesh PlayerNavMesh;
    public CameraFollow CameraFollow3;
    public CameraFollow CameraFollow5;
    public animationStateController animationStateController;
    public PlayerController playerController;
    public VignetteScritp vignette;
    public int level = 0;
    public float changeDistance;

    public GameObject lvl2walls;

    // Start is called before the first frame update
    void Start()
    {
        wall.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PositionCheck();
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider != null)
        {
            PlayerNavMesh.LevelChange();
            PlayerNavMesh.navMeshAgent.destination = Position.transform.position;
            animationStateController.animator.SetBool("isWalking", true);
            playerController.staticAnimationPlayed = true;
            CameraFollow3.target = null;
        }
    }

    void PositionCheck()
    {



        if (Vector3.Distance(Player.position, Position.position) < changeDistance && playerController.staticAnimationPlayed)
        {
            PlayerNavMesh.navMeshAgent.enabled = false;
            animationStateController.animator.SetBool("isWalking", false);
            level = 1;

            inPosition = true;
            StartCoroutine(TimerOff());
            StartCoroutine(TimerOn());
        }
    }


    IEnumerator TimerOff()
    {
        yield return new WaitForSeconds(1);
        vignette.animator.SetBool("CameraChange", true);
        
        playerController.levelNumber = 0; 

    }

    IEnumerator TimerOn()
    {
        yield return new WaitForSeconds(2);
        playerController.staticAnimationPlayed = false;
        CameraFollow3.target = Player.transform;
        vignette.animator.SetBool("CameraChange", false);
        Camera3.SetActive(false);
        Camera5.SetActive(true);
        playerController.staticAnimationPlayed = false;
        wall.SetActive(true);
        lvl2walls.SetActive(false);
        //this.gameObject.SetActive(false);


    }
}
