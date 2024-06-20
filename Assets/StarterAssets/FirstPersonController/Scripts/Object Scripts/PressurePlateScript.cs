using System.Collections;
using System.Collections.Generic;


using UnityEngine;

public class PressurePlateScript : MonoBehaviour
{
    public GameObject StoneDoor;
    [SerializeField] bool platePressured;
    [SerializeField] private float openingSpeed;
    [SerializeField] private float closingSpeed;
    [SerializeField] private int objectsAtPlate = 0;
    private Vector3 scaleChange;
    private Vector3 doorScale;
    public float doorScaleValue = 1f;
    public float decreaseRate = 0.05f;
    public float currentValue;

    public AudioSource src;
    public AudioSource src2;
    public AudioSource src3;
    public AudioClip clip;

    bool playCount = false;

    public float height;

    public GameObject pressurePlate;
    
    public animationStateController controller;

    public bool doorOpened;
    public bool doorClosed;
    public bool doorOpening;
    public bool doorClosing;
    // Update is called once per frame
    void Update()
    {
        StoneDoorOpening();
        StoneDoorClosing();
        //Debug.Log(objectsAtPlate);
        ObjectCheck();
        SoundPlaying();
    }

    private void Start()
    {
        currentValue = doorScaleValue;
    }

    public void OnTriggerEnter(Collider collider)
    {
        src3.mute = true;
        src2.mute = false;
        src2.pitch = 0.8f;
        src2.PlayOneShot(clip);
        doorOpening = true;

        if (playCount == false)
        {
            src.pitch = 0.8f;
            src.Play();
            
            playCount = true;
        }
        
        

        {
            if (collider != null && controller.canPushD)

            {
                platePressured = true;
                objectsAtPlate = objectsAtPlate + 2;
                //scaleChange = new Vector3(1.849517f, 0.001f, 2.135503f);
                pressurePlate.transform.position = new Vector3(transform.position.x, -0.18f, transform.position.z);
                //gameObject.transform.localScale = scaleChange;
                Debug.Log(collider);
                 
            }

            if (collider != null && !controller.canPushD)

            {
                platePressured = true;
                objectsAtPlate = objectsAtPlate + 1;
                //scaleChange = new Vector3(1.849517f, 0.001f, 2.135503f);
                pressurePlate.transform.position = new Vector3(transform.position.x, -0.18f, transform.position.z);
                //gameObject.transform.localScale = scaleChange;
                Debug.Log(collider);
            }

        }
    }




    public void OnTriggerExit(Collider collider)
    {

        src.pitch = 0.6f;
        src.Play();
        src2.mute = true;
        src3.mute = false;
        playCount = false;
        src3.pitch = 0.6f;
        src3.PlayOneShot(clip);
        doorClosing = true;
        ;

        {

            if (collider != null && controller.canPushD)

            {
                objectsAtPlate = objectsAtPlate - 2;
            }


            if (collider != null && !controller.canPushD)

            {
                objectsAtPlate = objectsAtPlate - 1;
            }





        }
    }







    void StoneDoorOpening()
    {

        if (StoneDoor.transform.position.y >= height)
        {
            src2.mute = true;
        }


        if (platePressured && StoneDoor.transform.position.y <= height && objectsAtPlate >= 1)
        {
            StoneDoor.transform.Translate(Vector3.up * openingSpeed * Time.deltaTime);
            doorOpened = false;
            

        }

        if ((platePressured && StoneDoor.transform.position.y < 0f && objectsAtPlate >= 1))
        {
            StoneDoor.transform.Translate(Vector3.up * openingSpeed * Time.deltaTime);

            
        }
    }

    void StoneDoorClosing()
    {

        if(StoneDoor.transform.position.y < 0.01f)
            {
                src3.mute = true;
            }

        if (StoneDoor.transform.position.y > 0f && !platePressured && objectsAtPlate < 1)
        {
            StoneDoor.transform.Translate(Vector3.down * closingSpeed * Time.deltaTime);
            doorClosed=false;
            
        }
    }
   void ObjectCheck()
    {
        if (objectsAtPlate < 1)

        {
            platePressured = false;
            pressurePlate.transform.position = new Vector3(transform.position.x, -0.12f, transform.position.z);
            //gameObject.transform.localScale = scaleChange;
        }

        if (objectsAtPlate > 3)
        {
            objectsAtPlate = 3;
        }
        if (objectsAtPlate < 0)
        {
            objectsAtPlate = 0;
        }
    }

   void SoundPlaying()
    {
        
    }
}
