using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//put this script on the player
public class ItemCollector : MonoBehaviour
{
    private int candies = 0;

    //connect the UI text (LEGACY) to this field
    [SerializeField] 
    private Text candiesText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Candy"))
        {
            Destroy(collision.gameObject);
            candies++;
            candiesText.text = candies.ToString();
        }
    }

    public int getCandies()
    {
        return candies;
    }
    public void setCandies(int sentCandies)
    { 
        candies = sentCandies;
    }
}
