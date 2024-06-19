using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    public bool isInShadow = true;
    public bool isInLight = false;
    public float health = 100f;
    public bool hasTorch = true;
    public GameObject torch;




    public animationStateController animationStateController;
    public PlayerController playerController;


    public TorchInteraction torchInteraction;

    // Update is called once per frame
    void Update()
    {
        PlayerHealth();
        TorchActive();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Light"))
        {

            isInLight = true;

        }


    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Light"))
        {
            isInLight = false; 
        }
    }

  



    public void PlayerHealth()
    {
        if (!isInLight)
        {
            health -= 0.01f;

            //Debug.Log(health);
            
            if (health < 0)
            {
                Death();
            }

        }
        else
        {
            if (health < 100)
            {
                health += 0.01f;
            }
            
                
        }
    }

    public void TorchActive()
    {

        if (torchInteraction.hasTorch) 
        {
            hasTorch = true;

            if (hasTorch && torch.activeInHierarchy == true)
            {
                isInLight = true; 
            }
        
        }  

        if (torchInteraction.hasTorch == false)
        {
            hasTorch = false;   
        }


        
    }


    public void Death()
    {
        playerController.staticAnimationPlayed = true;
        animationStateController.animator.SetBool("isWalking", false);
        animationStateController.animator.SetBool("isDead", true);
        
    }
}

    
