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

    [SerializeField] private Listener[] listeners;
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


    public abstract class Listener : MonoBehaviour
    {
        public abstract void Atualizar(SaveData data);
    }

    private void AnunciaVolume()
    {
        foreach (Listener listener in listeners)
        {
            listener.Atualizar(data);
        }
    }
}
