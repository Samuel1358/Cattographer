using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Timer : MonoBehaviour
{
    Timer_Dungeon timer;
    public float dano = 1f;

    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<Timer_Dungeon>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Inimigo"))
        {
            timer.timerDD -= dano;
        }
    }
}
