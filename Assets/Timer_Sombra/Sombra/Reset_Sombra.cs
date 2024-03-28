using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset_Sombra : MonoBehaviour
{
    Timer_Sombra sombra;
    int count = 3;

    // Start is called before the first frame update
    void Start()
    {
        sombra = FindObjectOfType<Timer_Sombra>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (count <= 0)
        {
            if (other.CompareTag("Player"))
            {
                sombra.timerSombra = sombra.ttSombra;
            }
        }
        if (count > 0)
        {
            count -= 1;
        }
    }
}
