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
    
    

    // Update is called once per frame
    void Update()
    {
        StoneDoorOpening();
        StoneDoorClosing();
        //Debug.Log(objectsAtPlate);
        ObjectCheck();
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))

        {
            platePressured = true;
            objectsAtPlate = objectsAtPlate + 1;
            scaleChange = new Vector3(1.849517f, 0.02f, 2.135503f);
            gameObject.transform.localScale = scaleChange;
        }
        if (collider.CompareTag("Vase"))
        {
            platePressured = true;
            objectsAtPlate = objectsAtPlate +1;
            scaleChange = new Vector3(1.849517f, 0.02f, 2.135503f);
            gameObject.transform.localScale = scaleChange;
        }
        

    }

    public void OnTriggerExit(Collider collider)

    {

       
        if (collider.CompareTag("Player"))

        {
            objectsAtPlate--;
            

        }
        if (collider.CompareTag("Vase"))

        {
            objectsAtPlate--;
            

        }

    }

    



    void StoneDoorOpening()
    {
        if (platePressured && StoneDoor.transform.position.y <= 7f && objectsAtPlate >= 1)
        {
            StoneDoor.transform.Translate(Vector3.up * openingSpeed * Time.deltaTime);
        }
    }

    void StoneDoorClosing()
    {
        if (StoneDoor.transform.position.y > 2.6f && !platePressured && objectsAtPlate < 1)
        {
            StoneDoor.transform.Translate(Vector3.down * closingSpeed * Time.deltaTime);
        }
    }
   void ObjectCheck()
    {
        if (objectsAtPlate < 1)

        {
            platePressured = false;
            scaleChange = new Vector3(1.849517f, 0.055f, 2.135503f);
            gameObject.transform.localScale = scaleChange;
        }

        if (objectsAtPlate > 2)
        {
            objectsAtPlate = 2;
        }
        if (objectsAtPlate < 0)
        {
            objectsAtPlate = 0;
        }
    }
}
