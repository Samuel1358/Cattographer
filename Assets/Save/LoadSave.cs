using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSave : MonoBehaviour
{
    [SerializeField] SaveData data;

    public enum Acao
    {
        Save,
        Load,
        Reset,
    }

    public Acao acao;

    [SerializeField] private Volume[] volumeListeners;
    void Start()
    {
        Debug.Log(Application.persistentDataPath);
        FazerAcontecer(acao);
    }

    public void FazerAcontecer(int acao) => FazerAcontecer((Acao)acao);
    public void FazerAcontecer(Acao acao)
    {
        switch (acao)
        {
            case Acao.Save:
                SaveSystem.Save(data);
                break;
            case Acao.Load:
                SaveSystem.Load(data);
                break;
            case Acao.Reset:
                data.Resetar();
                //SaveSystem.Save(data);
                break;
        }
        AnunciaVolume();
    }

    private void AnunciaVolume()
    {
        foreach (Volume listener in volumeListeners)
        {
            listener.Atualizar(data);
        }
    }
}
