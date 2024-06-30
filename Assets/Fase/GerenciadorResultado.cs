using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorResultado : MonoBehaviour
{
    [HideInInspector] [SerializeField] FasesLiberadas fases;
    Gerenciador_Fase resultado;

    public int idFase;

    [SerializeField] private LoadSave save;
    public enum Resultado
    {
        Win,
        Lose,
    }
    public Resultado tipo;

    // Start is called before the first frame update
    void Start()
    {
        if ((resultado = FindObjectOfType<Gerenciador_Fase>()) != null)
        {
            idFase = resultado.idFase;
            if (idFase == 1)
            {
                if (resultado.reliquias >= 3 && tipo == Resultado.Win)
                {
                    fases.Fase2 = true;
                    save.FazerAcontecer(LoadSave.Acao.Save);
                }
            }

            Destroy(resultado.gameObject);
        }
    }
}
