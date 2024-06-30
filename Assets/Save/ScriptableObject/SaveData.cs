using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveData")]
public class SaveData : ScriptableObject
{
    [SerializeField] Seletor_Linguagem seletorLinguagem;
    [SerializeField] FasesLiberadas fasesLiberadas;

    public Seletor_Linguagem.Linguagem lingua = Seletor_Linguagem.Linguagem.Portugues;
    public float volume = 1;
    public bool[] progrecao = new bool[2] {true, false};

    public void Insert()
    {
        seletorLinguagem.lingua = lingua;
        Gerenciador_Audio.Volume(volume);
        fasesLiberadas.Fase1 = progrecao[0];
        fasesLiberadas.Fase2 = progrecao[1];
    }

    public void Resetar()
    {
        lingua = Seletor_Linguagem.Linguagem.Portugues;
        volume = 1;
        progrecao[0] = true;
        progrecao[1] = false;
    }
}
