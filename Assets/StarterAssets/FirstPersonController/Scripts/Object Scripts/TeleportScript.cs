using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{

    public GameObject player;
    public GameObject targetPosition;
    public bool inPosition;
    public Level3Transition level3transition;
    public PlayerController playerController;
    public AxeTrapScript axetrap;
    public AxeTrapScript axeTrap2;
    public AxeTrapScript axeTrap3;
    public Level6Transistion level6transistion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(level3transition.inPosition)
        {
            player.transform.position = targetPosition.transform.position;  
             
            if (player.transform.position == targetPosition.transform.position)
            {
                level3transition.inPosition = false;
                playerController.levelNumber = 2;
                axetrap.trapOn = true;
                axeTrap2.trapOn = true;
                axeTrap3.trapOn = true;
            }
        } 
    }
}
