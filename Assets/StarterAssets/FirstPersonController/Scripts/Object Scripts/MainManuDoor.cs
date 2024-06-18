using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainManuDoor : MonoBehaviour
{
    public MainMenu menu;
    public GameObject StoneDoor;
    public bool playClicked = false;
    public float openingSpeed;

    public PlayerNavMesh playerNavMesh;
    public PlayerController playerController;
    public animationStateController animationStateController;

    public Transform finishPoint;
    public Transform player;

    public bool doorInPosition;

    public bool doorClosed;

    // Update is called once per frame
    void Update()
    {
        DoorOpening();
        PlayerMove();
        PlayTrigger();
        
    }

    public void DoorOpening()
    {
        if (playClicked && StoneDoor.transform.position.y <= 6.9f && doorInPosition == false)
        {
            StoneDoor.transform.Translate(Vector3.up * openingSpeed * Time.deltaTime);
            
            if (playClicked && StoneDoor.transform.position.y >= 6.8f)
            {
                doorInPosition = true;

            }
            
        }
        else if (doorInPosition && StoneDoor.transform.position.y >= 0f)
        {
            StoneDoor.transform.Translate(Vector3.down * openingSpeed * Time.deltaTime);

            if (StoneDoor.transform.position.y <= 0.1f)
            {
                doorClosed = true;  
            }
        }


    }

    public void PlayerMove()
    {
        if (playClicked && StoneDoor.transform.position.y > 3f)
        {
            playerNavMesh.LevelChange();
            playerNavMesh.navMeshAgent.destination = finishPoint.position;
            animationStateController.animator.SetBool("isWalking", true);

            
        }
        else if (Vector3.Distance(player.transform.position, finishPoint.position) < 3f)
        {
            playerNavMesh.navMeshAgent.enabled = false;
            animationStateController.animator.SetBool("isWalking", false);

        }
    }

    public void PlayTrigger()
    {
        if (doorClosed)
        {
            menu.LoadScene();
        }
    }
}
