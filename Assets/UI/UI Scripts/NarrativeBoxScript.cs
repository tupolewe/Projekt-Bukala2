using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NarrativeBoxScript : MonoBehaviour
{

    public TextMeshProUGUI narrativeText; 
    public Animator animator;
    public string Text; 

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player")) 
        {
            
            animator.SetBool("Open", true);
            narrativeText.text = Text;

        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            animator.SetBool("Open", false);
            narrativeText.text = string.Empty;
            
        }
    }
}
