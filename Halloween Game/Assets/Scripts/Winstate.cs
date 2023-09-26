using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Winstate : MonoBehaviour
{
    const int maxLevel1Candies = 1;
    public ItemCollector itemCollector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkForAllItems();
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
