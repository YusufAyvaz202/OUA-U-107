using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    public Slider slider;

    public void SetMAxHealt(int healt)
    {
        slider.maxValue= healt;
        slider.value = healt;
    }

    public void SetHealt(int healt)
    {
        slider.value = healt;
    }

}
