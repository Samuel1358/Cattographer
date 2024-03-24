using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display_Sombra : MonoBehaviour
{
    Timer_Sombra timer;
    public Text texto;
    int min, sec;

    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<Timer_Sombra>();
    }

    // Update is called once per frame
    void Update()
    {
        min = Mathf.FloorToInt(timer.timerSombra / 60);
        sec = Mathf.FloorToInt(timer.timerSombra % 60);
        texto.text = "Timer: " + string.Format("{0:00}:{1:00}", min, sec);
    }
}
