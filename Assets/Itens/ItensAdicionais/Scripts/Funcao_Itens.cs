using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Funcao_Itens : MonoBehaviour
{
    Timer_Sombra sombra;

    // Start is called before the first frame update
    void Start()
    {
        sombra = FindAnyObjectByType<Timer_Sombra>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Bomba()
    {
        //@
    }

    public void Tabua()
    {
        //@
    }

    public void Kyrozene()
    {
        sombra.timerSombra = sombra.ttSombra;
    }
}
