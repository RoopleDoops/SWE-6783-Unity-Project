using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Level_00");
        }
    }

    public void StartButtonPressed()
    {
        SceneManager.LoadScene("Level_00");
    }


}
