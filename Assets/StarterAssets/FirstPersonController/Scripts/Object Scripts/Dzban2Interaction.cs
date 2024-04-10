using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dzban2Interaction : MonoBehaviour, Interactable
{

    public GameObject dzban2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void TransformDzban()
    {
        dzban2.transform.position = new Vector3 (5f, 5f, 5f);
    } 

    public void Interact()
    {
        TransformDzban();
    }
}
