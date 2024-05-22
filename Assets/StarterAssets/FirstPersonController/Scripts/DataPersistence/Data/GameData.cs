using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData 
{
    public int level;


    //the values defined in contructor will be default, the game starts with them when there is no data to load
    public GameData() 
    {
        this.level = 0;
    }
}
