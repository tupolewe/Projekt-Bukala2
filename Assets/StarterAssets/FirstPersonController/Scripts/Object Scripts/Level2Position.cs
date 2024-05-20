using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Position : MonoBehaviour
{

    public Transform Position;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == null)
        {
            Debug.Log("yeahhh");
        }
    }
}
