using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    private float qTime = 0f;
    private float qTimeMax = 2.5f;
    private float imageScale = 0f;
    private RectTransform quitImage;
    void Start()
    {
        quitImage = GameObject.Find("Quit_Image_X").GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            // Countdown to quit game if escape is held
            qTime += Time.deltaTime;
            imageScale = 0.25f + ((qTime / qTimeMax) * 0.5f);
            quitImage.localScale = new Vector3(imageScale, imageScale, 1);
            if (qTime >= qTimeMax)
            {
                Application.Quit();
            }

        }
        else
        {
            imageScale = 0f;
            quitImage.localScale = new Vector3(imageScale, imageScale, 1);
            qTime = 0f;
        }
    }
}