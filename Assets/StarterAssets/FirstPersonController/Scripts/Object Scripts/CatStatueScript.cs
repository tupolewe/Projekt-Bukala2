using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CatStatueScript : MonoBehaviour, Interactable
{
    public RayCastInteraction rayCast;
    public GoldMenager goldMenager;
    public TextMeshProUGUI actionHint;
    public EndDoorScript endDoorScript;
    public int catgold;
    public CatGoldMenager catGoldMenager; 
    public void Interact()
    {

            Debug.Log("oddanie zlota");
            
            Debug.Log(goldMenager.goldCount);

        if (goldMenager.goldCount == 1)
        {
            endDoorScript.platePressured = true;
            goldMenager.goldCount--;
            catgold++;
            
            
        }
        goldMenager.goldCount--;



    }

    public void Update()
    {
        if (rayCast.currentHitObject.GetComponent("CatStatueScript") && goldMenager.goldCount > 0)
        {
            
            actionHint.text = "Press 'E' to present Golden Bar";
        }


    }
}
