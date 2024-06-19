using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDoorScript : MonoBehaviour
{
    public GameObject StoneDoor;
    public bool platePressured;
    [SerializeField] private float openingSpeed;
    [SerializeField] private float closingSpeed;
    
    
    public float doorScaleValue = 1f;
    public float decreaseRate = 0.05f;
    public float currentValue;

    public AudioSource src;
    public AudioSource src2;

   

    public float height;

    public GameObject pressurePlate;

    public animationStateController controller;
    // Update is called once per frame
    void Update()
    {
        StoneDoorOpening();
       
        
       
    }

    private void Start()
    {
        
    }

   



   






    void StoneDoorOpening()
    {
        if (platePressured) 
        {
            StoneDoor.transform.Translate(Vector3.up * openingSpeed * Time.deltaTime);
        }



        

      
    }

   
   
}
