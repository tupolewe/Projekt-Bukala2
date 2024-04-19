using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;
    private NavMeshAgent navMeshAgent;
    public bool isHandlingTriggered = false;
    public GameObject Player;
    public animationStateController animationStateController; 
    
    

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        
        
    }

    

    // Update is called once per frame
    void Update()
    {
        MoveToHandlePosition();
        
    }

    void MoveToHandlePosition()
    {
        bool movementKey = Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.D);
        if (movementKey)
        {
            navMeshAgent.enabled = false;
            
        }

        if (isHandlingTriggered)
        {
            if (animationStateController.isHandlingRunning)
            {
                navMeshAgent.enabled = true;
                navMeshAgent.destination = movePositionTransform.position;
                navMeshAgent.updateRotation = false;
                Player.transform.rotation = Quaternion.Euler(0, 270, 0);

                
                

            }
            
           
            
            
        }
    }
}
