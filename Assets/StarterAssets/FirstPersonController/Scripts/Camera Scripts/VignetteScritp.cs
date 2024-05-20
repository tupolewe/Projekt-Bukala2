using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VignetteScritp : MonoBehaviour
{
    int cameraChangeHash;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); 
        cameraChangeHash = Animator.StringToHash("CameraChange");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
