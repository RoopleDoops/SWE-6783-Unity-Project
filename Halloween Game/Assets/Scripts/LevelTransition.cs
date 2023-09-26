using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public void loadNextLevel(int levelNumber)
    {
        if (levelNumber < 0)
        {
            SceneManager.LoadScene(levelNumber);
        }
    }
    public void reloadCurrentLevel()
    {

    }
    public void resetCounters() 
    {
        //reset ui elements 
    }
    public void resetHealth()
    {

    }
    public void resetCollectables()
    {
       //resetCollectables 
    }
}
