using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTest : MonoBehaviour
{
    [HideInInspector] [SerializeField] FasesLiberadas fasesLiberadas;
    [SerializeField] Toggle caixa;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (caixa != null)
        {
            fasesLiberadas.Fase2 = caixa.isOn;
        }
    }
}
