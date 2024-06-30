using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{

    [SerializeField] private Tipo tipo;
    enum Tipo
    {
        Musica,
        SFX,
    }

    private Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void Atualizar(SaveData saveData)
    {
        switch (tipo)
        {
            case Tipo.Musica:
                slider.value = saveData.volumeMusica;
                break;
            case Tipo.SFX:
                slider.value = saveData.volumeSFX;
                break;
        }
    }
}
