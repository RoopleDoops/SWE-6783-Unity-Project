using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Winstate : MonoBehaviour
{
    const int maxLevel1Candies = 1;
    private int currentLvl = 1;
    public ItemCollector itemCollector;
    public LevelTransition levelTransition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (checkForAllItems()) 
        {
            levelTransition.loadNextLevel(currentLvl++);
        };
    }
    bool checkForAllItems()
    { 
        if(itemCollector.getCandies() == maxLevel1Candies)
        {
            return true;
        }
        return false;
    }
}
