using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Timer : MonoBehaviour
{
    Timer_Sombra sombra;
    public float dano = 1f;

    // Start is called before the first frame update
    void Start()
    {
        sombra = FindObjectOfType<Timer_Sombra>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Inimigo"))
        {
            sombra.timerSombra -= dano;
        }
    }
}
