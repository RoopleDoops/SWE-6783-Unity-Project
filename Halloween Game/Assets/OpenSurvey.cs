using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSurvey : MonoBehaviour
{
    private bool surveyOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!surveyOpened && Input.anyKey)
        {
            //Application.OpenURL("https://forms.gle/FYF33sb3RNk89NrG6");
            surveyOpened = true;
            Application.Quit();
        }
    }
}
