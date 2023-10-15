using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winstate : MonoBehaviour
{
    const int maxLevel1Candies = 5;
    private int currentLvl = 0;
    Dictionary<string, int> levelCandies = new Dictionary<string, int>
        {
            { "1", 5 },
            { "2", 5 },
            { "3", 5 }
        };
    public ItemCollector itemCollector;
    public LevelTransition levelTransition;
    private bool won;

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string currentSceneName = currentScene.name;
        currentLvl =  Convert.ToInt32(currentSceneName.Substring(currentSceneName.Length - 1));
    }
    // Update is called once per frame
    void Update()
    {
        if(currentLvl == 3 && checkForAllItems() && !won)
        {
            won = true;
            StartCoroutine(playerWinGame());
        }
        if (checkForAllItems() && !won)
        {
            won = true;
            StartCoroutine(playerWinLevel()); //waits before moving to next level "animation" and sound
        }
    }
    bool checkForAllItems()
    {
        if (itemCollector.getCandies() == maxLevel1Candies)
        {
            return true;
        }
        return false;
    }

    private IEnumerator playerWinLevel()
    {
        itemCollector.win();
        yield return new WaitForSeconds(3f);
        currentLvl += 1;
        levelTransition.loadNextLevel(currentLvl);
    }
    private IEnumerator playerWinGame()
    {
        itemCollector.win();
        yield return new WaitForSeconds(3f);
        currentLvl = 1;
        levelTransition.loadNextLevel(currentLvl);
    }
}