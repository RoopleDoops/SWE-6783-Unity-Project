using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public PlayerLife life;
    public LevelTransition transition;
    public ItemCollector collector;

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
         
    }
    public void resetHealth()
    {
        life.setCurrentHealth(3);
    }
    public void resetCollectables()
    {
        collector.setCandies(0);
    }
}
