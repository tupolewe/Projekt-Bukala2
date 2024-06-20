using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;

public class NarrativeUIScript : MonoBehaviour
{

    public GameObject MainCamera;
    public GameObject narrativeUI;
    public GameObject narrativeText;
    // Start is called before the first frame update
    void Start()
    {
        narrativeUI.transform.localScale = new Vector3(0, 29, 29);
        narrativeText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - MainCamera.transform.position);
        ScaleCheck();
    }


    void ScaleCheck()
    {
        if (narrativeUI.transform.localScale == new Vector3(29, 28.878f, 28.878f))
        {
            narrativeText.SetActive(true);
        }
        else
        {
            narrativeText.SetActive(false);
        }
    } 
}


