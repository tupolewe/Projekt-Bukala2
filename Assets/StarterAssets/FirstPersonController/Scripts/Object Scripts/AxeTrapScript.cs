using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class AxeTrapScript : MonoBehaviour
{

    public Transform axe1;
    public Transform axe2;
    public Transform railEnd1;
    public Transform railEnd2;
    public bool trapOn;
    public float speed;

    public AudioSource src;
    int direction1 = 1;
    int direction2 = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = currentMoveTarget();
        Vector3 target2 = currentMoveTarget2();

        axe1.transform.position = Vector3.Lerp(axe1.transform.position, target, speed * Time.deltaTime);
        axe2.transform.position = Vector3.Lerp(axe2.transform.position, target2, speed * Time.deltaTime);

        float distance1 = (target - axe1.transform.position).magnitude;
        float distance2 = (target - axe2.transform.position).magnitude;

        if (distance1 <= 0.5f) 
        {
            direction1 *= -1;

            src.Play();

            if (direction1 == 1)
            {
                //Debug.Log("obrot");
                axe1.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            

            else if (direction1 < 1)
            {
                //Debug.Log("obrot");
                axe1.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            }

        }

        if (distance2 <= 0.5f)
        {
            direction2 *= -1;

            if ((direction2 == 1))
            {
                //Debug.Log("obrot");
                axe2.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }


            else if (direction2 < 1)
            {
                //Debug.Log("obrot");
                axe2.transform.rotation = Quaternion.Euler(0f, 180f, 0f);

            }
        }
    }

    Vector3 currentMoveTarget()
    {
        if (direction1 == 1) 
        {
            return railEnd1.position; 

        }
        else
        {
             return railEnd2.position;
        }


    }

    Vector3 currentMoveTarget2()
    {
        if (direction2 == 1)
        {
            return railEnd2.position;

        }
        else
        {
            return railEnd1.position;
        }
    }

    
   

}
