using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display_Timer : MonoBehaviour
{
    Timer_Dungeon timer;
    public Text texto;
    int min, sec;

    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<Timer_Dungeon>();
    }

    // Update is called once per frame
    void Update()
    {
        min = Mathf.FloorToInt(timer.timerDD / 60);
        sec = Mathf.FloorToInt(timer.timerDD % 60);
        texto.text = "Timer: " + string.Format("{0:00}:{1:00}", min, sec);
    }
}
