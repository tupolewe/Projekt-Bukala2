using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class Level3Transition : MonoBehaviour
{

    public Transform Player;
    public Transform Position;

    public GameObject Camera2;
    public GameObject Camera3;
    public PlayerNavMesh PlayerNavMesh;
    public CameraFollow CameraFollow2;
    public CameraFollow CameraFollow3;
    public animationStateController animationStateController;
    public PlayerController playerController;
    public VignetteScritp vignette;
    public int level = 0;
    public float changeDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PositionCheck();
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider != null && level == 0)
        {
            PlayerNavMesh.LevelChange();
            PlayerNavMesh.navMeshAgent.destination = Position.transform.position;
            animationStateController.animator.SetBool("isWalking", true);
            playerController.staticAnimationPlayed = true;
            CameraFollow2.target = null;
        }
    }

    void PositionCheck()
    {

        

        if (Vector3.Distance(Player.position, Position.position) < changeDistance && playerController.staticAnimationPlayed)
        {
            PlayerNavMesh.navMeshAgent.enabled = false;
            animationStateController.animator.SetBool("isWalking", false);
            level = 1;

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
        vignette.animator.SetBool("CameraChange", false);
        Camera2.SetActive(false);
        Camera3.SetActive(true);
        playerController.staticAnimationPlayed = false;
        
        CameraFollow3.target = Player.transform;
        
    }
}
