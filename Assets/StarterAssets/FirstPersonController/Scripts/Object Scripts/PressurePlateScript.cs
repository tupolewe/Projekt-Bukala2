using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor.ShaderGraph.Internal;
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

    bool playCount = false;


    public GameObject pressurePlate;
    
    public animationStateController controller;
    // Update is called once per frame
    void Update()
    {
        StoneDoorOpening();
        StoneDoorClosing();
        //Debug.Log(objectsAtPlate);
        ObjectCheck();
    }

    private void Start()
    {
        currentValue = doorScaleValue;
    }

    public void OnTriggerEnter(Collider collider)
    {

        

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
        playCount = false;


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
        



            if (platePressured && StoneDoor.transform.position.y <= 7f && objectsAtPlate >= 1)
        {
            StoneDoor.transform.Translate(Vector3.up * openingSpeed * Time.deltaTime);

            

        }

        if ((platePressured && StoneDoor.transform.position.y < 0f && objectsAtPlate >= 1))
        {
            StoneDoor.transform.Translate(Vector3.up * openingSpeed * Time.deltaTime);

            
        }
    }

    void StoneDoorClosing()
    {

        

        if (StoneDoor.transform.position.y > 0f && !platePressured && objectsAtPlate < 1)
        {
            StoneDoor.transform.Translate(Vector3.down * closingSpeed * Time.deltaTime);

            
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

   
}
