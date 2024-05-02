using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display2_Timer : MonoBehaviour
{
    Timer_Dungeon timer;
    Slider slider;
    float tt;

    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<Timer_Dungeon>();
        slider = GetComponent<Slider>();

        tt = timer.timerDD;
        slider.maxValue = tt;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = timer.timerDD;
    }
}
