using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luz : MonoBehaviour
{
    Light luzes;
    Timer_Sombra sombras;

    // Start is called before the first frame update
    void Start()
    {
        luzes = GetComponent<Light>();
        sombras = FindAnyObjectByType<Timer_Sombra>();
    }

    // Update is called once per frame
    void Update()
    {
        luzes.spotAngle = (sombras.timerSombra * 2f) + 4f;
    }
}
