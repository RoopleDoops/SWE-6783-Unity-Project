using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBr : MonoBehaviour
{
    public Slider slidctrl;
    public Gradient grad;
    public Image fill;
    public void Maxhealth(int health)
    {

        slidctrl.maxValue = health;
        slidctrl.value = health;

        
        fill.color = grad.Evaluate(1f);
    }
    public void Health(int health)
    {

        slidctrl.value = health;
        fill.color = grad.Evaluate(slidctrl.normalizedValue);
    }
}
