using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatGoldMenager : MonoBehaviour
{
    public bool CatGold1;
    
    public EndDoorScript EndDoorScript;

    // Update is called once per frame
    void Update()
    {
        if (CatGold1)
        {
            EndDoorScript.platePressured = true;
        }
    }
}
