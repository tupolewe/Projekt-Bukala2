using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeTrapScript : MonoBehaviour
{

    public GameObject axe1;
    public GameObject axe2;
    public Transform railEnd1;
    public Transform railEnd2;
    public bool trapOn;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AxeMove1();
    }


    void AxeMove1()
    {

        float distance1 = Vector3.Distance(axe1.transform.transform.position, railEnd1.position);
        float distance2 = Vector3.Distance(axe2.transform.transform.position, railEnd2.position);

        if (trapOn)
        {
            if (distance1 > 1f)
            {
                axe1.transform.Translate(Vector3.right * speed * Time.deltaTime);
                
            }
            if (distance2 > 1f)
            {
                axe2.transform.Translate(Vector3.right * speed * Time.deltaTime);
            }

        }
        
    }
}
