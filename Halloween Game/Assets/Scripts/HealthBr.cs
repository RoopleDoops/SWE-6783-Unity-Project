using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBr : MonoBehaviour
{
    public Slider slidctrl;
    public Gradient grad;
    public Image Fill;
    public void Maxhealth(int health)
    {

        slidctrl.maxValue = health;
        slidctrl.value = health;

        
        Fill.color = grad.Evaluate(1f);
    }
    public void Health(int health)
    {

        slidctrl.value = health;
        Fill.color = grad.Evaluate(slidctrl.normalizedValue);
    }
}
