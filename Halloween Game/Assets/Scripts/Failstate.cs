using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Failstate : MonoBehaviour
{
    public PlayerLife life;
    public LevelTransition transition;
    // Update is called once per frame
    void Update()
    {
        if (checkForCurrentHealth() == false|| checkForRemainingTime() == false)
        {
            life.killPlayer();  
        }
        
    }

    bool checkForCurrentHealth()
    {
        if (life.getCurrentHealth() > 0)
        {
            return true;
        }
        return false;
    }
    bool checkForRemainingTime()
    {
        return true;
    }
}
