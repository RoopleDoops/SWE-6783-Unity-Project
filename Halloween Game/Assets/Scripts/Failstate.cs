using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Failstate : MonoBehaviour
{
    public PlayerLife life;
    public LevelTransition transition;
    public Timer timer;
    // Update is called once per frame
    void Update()
    {
        if ((checkForCurrentHealth() == false || checkForRemainingTime() == false) && !life.isDead())
        {
            StartCoroutine(playerDeath()); //waits before resetting for death "animation" and sound
        }

    }
    private IEnumerator playerDeath()
    {
        life.killPlayer();
        yield return new WaitForSeconds(1.5f);
        transition.reloadCurrentLevel();
        transition.resetHealth();
        transition.resetCollectables();
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
       if(timer.getCurrentTime() != 0) { 
            return true;
        }
       return false;
    }
}