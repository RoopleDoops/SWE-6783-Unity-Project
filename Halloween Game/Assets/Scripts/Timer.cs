using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public bool Stop { get; set; }
    float currTme = 0f;
    float startTme = 30f;
    // Start is called before the first frame update lmao ok

    [SerializeField] Text Time_clock;

    void Start()
    {
        currTme = startTme;
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
