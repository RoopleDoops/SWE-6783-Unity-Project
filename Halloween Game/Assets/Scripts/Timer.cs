using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{

    float currTme = 0f;
    float startTme = 60f;
    // Start is called before the first frame update

    [SerializeField] Text Time_clock;

    void Start()
    {
        currTme = startTme;
    }

    // Update is called once per frame
    void Update()
    {
        currTme -= 1 * Time.deltaTime;
        Time_clock.text = currTme.ToString("Time: 0");

        if (currTme <= 0)

        {
            currTme = 0;

        }
    }
}
