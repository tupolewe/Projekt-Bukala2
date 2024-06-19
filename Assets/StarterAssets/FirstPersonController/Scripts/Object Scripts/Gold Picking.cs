using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.XR;

public class GoldPicking : MonoBehaviour, Interactable
{
    public RayCastInteraction rayCast;
    public GoldMenager goldMenager;
    public TextMeshProUGUI actionHint;
    public void Interact()
    {
        if (rayCast.currentHitObject.GetComponent("GoldPicking"))
        {
            goldMenager.goldCount++;
            Debug.Log(goldMenager.goldCount);   
            this.gameObject.SetActive(false);
        }
    }

    public void Update()
    {
        if (rayCast.currentHitObject.GetComponent("GoldPicking"))
        {
            actionHint.text = "Press 'E' to collect Golden Bar";
        }
             

    }
}
