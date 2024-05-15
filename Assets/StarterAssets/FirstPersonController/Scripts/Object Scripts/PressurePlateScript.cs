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

            //doorScale = new Vector3(1, doorScaleValue, 1);
            //StoneDoor.transform.localScale = doorScale;

            //doorScaleValue = doorScaleValue - Time.deltaTime * 0.3f;
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
            scaleChange = new Vector3(1.849517f, 0.06f, 2.135503f);
            gameObject.transform.localScale = scaleChange;
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
