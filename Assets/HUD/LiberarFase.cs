using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiberarFase : MonoBehaviour
{
    [HideInInspector][SerializeField] FasesLiberadas fases;
    [SerializeField] GameObject botao;
    [SerializeField] GameObject locked;

    private void Update()
    {
        if (fases.Fase2)
        {
            botao.SetActive(true);
            locked.SetActive(false);
        }
        else
        {
            botao.SetActive(false);
            locked.SetActive(true);
        }
    }
}
