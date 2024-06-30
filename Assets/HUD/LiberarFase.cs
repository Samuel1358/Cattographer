using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiberarFase : MonoBehaviour
{
    [HideInInspector][SerializeField] FasesLiberadas fases;
    [SerializeField] GameObject botao;
    [SerializeField] GameObject locked;

    [SerializeField] private SaveData saveData;
    private void Update()
    {
        if (fases.Fase2)
        {
            botao.SetActive(true);
            locked.SetActive(false);
            saveData.progrecao[1] = true;
        }
        else
        {
            botao.SetActive(false);
            locked.SetActive(true);
        }
    }
}
