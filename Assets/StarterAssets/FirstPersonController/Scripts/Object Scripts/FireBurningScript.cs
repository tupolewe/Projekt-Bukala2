using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBurningScript : MonoBehaviour
{
    public PlayerController controller;
    public GameObject vaseLight;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {



        if (collider.CompareTag("TorchFire") && controller.staticAnimationPlayed)
        {
            vaseLight.SetActive(true);
            Debug.Log("fire");

            

            
            
        }
    }
}