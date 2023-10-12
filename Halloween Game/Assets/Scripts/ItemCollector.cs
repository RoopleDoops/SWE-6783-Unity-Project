using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//put this script on the player
public class ItemCollector : MonoBehaviour
{
    public GameObject Candy;
    public GameObject Candy2;
    public GameObject Candy3;
    public GameObject Candy4;
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
            if (candies == 1)
            {
                Candy.SetActive(true);
            }

            else if(candies == 2)
            {
               Candy2.SetActive(true);
            }

            else if(candies == 3)
            {
                Candy3.SetActive(true);
            }

            else if(candies == 4)
            {
                Candy4.SetActive(true);
            }
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
