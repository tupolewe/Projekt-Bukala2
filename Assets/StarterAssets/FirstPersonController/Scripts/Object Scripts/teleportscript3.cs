using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportscript3 : MonoBehaviour
{
     public GameObject player;
    public GameObject targetPosition;
    public bool inPosition;
    public Level3Transition level3transition;
    public PlayerController playerController;
    public AxeTrapScript axetrap;
    public AxeTrapScript axeTrap2;
    public AxeTrapScript axeTrap3;

    public Level6Transistion level6transition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (level6transition.inPosition)
        {
            player.transform.position = targetPosition.transform.position;

            if (player.transform.position == targetPosition.transform.position)
            {
                level6transition.inPosition = false;
                playerController.levelNumber = 0;
                axetrap.trapOn = false;
                axeTrap2.trapOn = false;
                axeTrap3.trapOn = false;
            }
        }
    }
}
