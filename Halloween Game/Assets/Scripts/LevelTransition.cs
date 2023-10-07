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
        if (levelNumber > 0)
        {
            SceneManager.LoadScene("Level_0" + levelNumber);
        }
    }
    public void reloadCurrentLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void resetCounters()
    {
        //reset scoreboard, ui elements 
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