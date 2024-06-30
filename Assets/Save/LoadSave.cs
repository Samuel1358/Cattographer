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

    void Start()
    {
        Debug.Log(Application.persistentDataPath);
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
    }
}
