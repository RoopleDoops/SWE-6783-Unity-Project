using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public bool Stop { get; set; }
    float currTme = 0f;
    float [] startTme = {20f, 30f, 40f, 50f};


    // Start is called before the first frame update lmao ok

    [SerializeField] Text Time_clock;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string currentSceneName = currentScene.name;
        int currentLvl = Convert.ToInt32(currentSceneName.Substring(currentSceneName.Length - 1));
        currTme = startTme[currentLvl];
    }


    // Update is called once per frame
    void Update()
    {
        if(Stop) return;
        currTme -= 1 * Time.deltaTime;
        Time_clock.text = currTme.ToString("0");

        if (currTme <= 10)
        {
            Time_clock.color = Color.red;
        }
        if (currTme <= 0)

        {
            currTme = 0;

        }
    }
    public float getCurrentTime()
    {
        return currTme;
    }
}
