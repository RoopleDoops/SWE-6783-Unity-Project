using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//put this script on the player
public class ItemCollector : MonoBehaviour
{
    public GameObject candy;
    public GameObject candy2;
    public GameObject candy3;
    public GameObject candy4;
    public GameObject candy5;
    

    private int candies = 0;

    private PlayerMovement move;
    private PlayerLife life;

    //Audio add in
    [SerializeField] 
    private AudioSource collectableGet;
    [SerializeField]
    private AudioSource winSound;

    //connect the UI text (LEGACY) to this field we're going to delete this
    [SerializeField] 
    private Text candiesText;

    private void Start()
    {
        move = GetComponent<PlayerMovement>();
        life = GetComponent<PlayerLife>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Candy"))
        {
            collectableGet.Play();
            Destroy(collision.gameObject);
            candies++;
            //candiesText.text = candies.ToString();
            if (candies == 1)
            {
                candy.SetActive(true);

            }

            else if (candies == 2)
            {
                candy2.SetActive(true);

            }

            else if (candies == 3)
            {
                candy3.SetActive(true);

            }

            else if (candies == 4)
            {
                candy4.SetActive(true);

            }

            else if (candies == 5)
            {
                candy5.SetActive(true);
            }
            
        }
        
    }
    public void win()
    {
        Destroy(GameObject.Find("BGM"));
        Destroy(GameObject.Find("Enemies"));
        move.enabled = false; //player loses control
        winSound.Play();
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
