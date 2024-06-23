using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset_Sombra : MonoBehaviour
{
    Timer_Sombra sombra;
    [SerializeField] bool descanco = false;
    [SerializeField] bool recarga = false;
    [SerializeField] float taxaQueda = 1;

    // Start is called before the first frame update
    void Start()
    {
        sombra = FindObjectOfType<Timer_Sombra>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sombra.taxaQueda = taxaQueda;
            if (descanco == true)
            {
                sombra.active = false;
            }
            else
            {
                sombra.active = true;
            }

            if (recarga == true)
            {
                sombra.timerSombra = sombra.ttSombra;
            }            
        }
    }

    public void DesativarSombra()
    {
        descanco = true;
        taxaQueda = 0;
        sombra.taxaQueda = taxaQueda;
    }
}
