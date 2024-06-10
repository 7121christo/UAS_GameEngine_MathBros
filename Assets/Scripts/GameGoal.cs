using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGoal : MonoBehaviour
{
    public static GameGoal singleton;
    public int NumberCollected;
    public int NumberNeeded;
    public bool EnterHouse;

    public void Awake(){
        singleton = this;
    }

    public void CollectNumber(){
        NumberCollected++;
        if (NumberCollected >= NumberNeeded)
        {
            EnterHouse = true;
        }
    }
}
