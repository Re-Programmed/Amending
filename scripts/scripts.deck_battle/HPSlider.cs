using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{
    public static HPSlider INSTANCE { get; private set; }

    int targetValue = 0;

    Slider slider;

    public void Awake()
    {
        if(INSTANCE == null)
        {
            INSTANCE = this;
            targetValue = Mathf.FloorToInt(GetComponent<Slider>().maxValue / 2);
            slider = GetComponent<Slider>();
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        if(targetValue > slider.value)
        {
            slider.value += 0.45f;
        }

        if (targetValue < slider.value)
        {
            slider.value -= 0.45f;
        }
    }

    public static Slider GetSlider()
    {
        return INSTANCE.slider;
    }

    public static void SetValue(int val)
    {
        INSTANCE.targetValue = val;
    }
}
