using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DeathPlateScript : MonoBehaviour
{

    public PlayerController controller;
    public animationStateController controllerState;
    public Rigidbody rb;
    public GameObject floor;
    public GameObject pressurePlate;

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
        if (collider != null)
        {
            controller.staticAnimationPlayed = true;
            controllerState.animator.SetBool("isWalking", false);

            StartCoroutine(TimerOff());
        }
    }

    IEnumerator TimerOff()
    {
        yield return new WaitForSeconds(1);
        
        rb.isKinematic = false;
        Destroy(floor);
        Destroy(pressurePlate);

       

    }

   
}
