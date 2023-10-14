using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private Vector3 location;
    private bool animSwapped;
    private bool passedSpace;

    void Start()
    {
        //hides space animation
        GameObject.Find("space").GetComponent<Renderer>().enabled = false;
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
    }
}
