using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    GameObject candy;
    [SerializeField]
    GameObject point;
    private Vector3 location;
    private bool animSwapped;
    private bool passedSpace;
    private bool nullCandy;
    private float pointTime = 0f;// used to make point icon blink
    private float pointTimeMax = 0.5f; 
    bool showPoint = false;

    void Start()
    {
        //hides space animation and candy pointer
        GameObject.Find("space").GetComponent<Renderer>().enabled = false;
        point.GetComponent<Image>().enabled = false;
    }
    void Update()
    {
        //gets player location
        location = this.gameObject.transform.position;

        //switches arrow key animation to space animation when you get to the first jump
        if((location.x > -8) && !animSwapped)
        {
            animSwapped = true;
            GameObject.Find("arrow_keys").GetComponent<Renderer>().enabled = false;
            GameObject.Find("space").GetComponent<Renderer>().enabled = true;
        }

        //takes away space once you're past the first jump
        if(location.x > 0 && !passedSpace)
        {
            passedSpace = true;
            GameObject.Find("space").GetComponent<Renderer>().enabled = false;
        }

        //checks to see if first candy has been grabbed, adds arrow.
        if(candy == null && !nullCandy)
        {
            pointTime -= Time.deltaTime;
            if (pointTime <= 0f)
            {
                showPoint = !showPoint;
                point.GetComponent<Image>().enabled = showPoint;
                pointTime = pointTimeMax;
            }
            //nullCandy = true;
        }   
    }
}
