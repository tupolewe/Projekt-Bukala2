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
    
    
    // Update is called once per frame
    void Update()
    {
        PlayerHealth();
        TorchActive();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shadow"))
        {
            
            isInShadow = true;

        }


    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Light"))
        {
            isInLight = false;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Light"))
        {
            isInLight = true;
        }
        else if (other.gameObject.CompareTag("Torch"))
        {
            hasTorch = true;
        }
    }



    public void PlayerHealth()
    {
        if (!isInLight && isInShadow && !hasTorch)
        {
            health -= 0.001f;

            //Debug.Log(health);


        }
    }

    public void TorchActive()
    {
            //if (Input.GetKeyDown(KeyCode.F)) 
        {
            //torch.SetActive(false);
            //hasTorch = false;
        }
            //if (Input.GetKeyUp(KeyCode.F))
        {
            //torch.SetActive(true);
            //hasTorch = true;
        }
    }
}
