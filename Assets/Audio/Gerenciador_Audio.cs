using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerenciador_Audio : MonoBehaviour
{
    static private Gerenciador_Audio instance;

    [SerializeField] private AudioClip musica;

    private AudioSource audioSource;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();
        }
        else Destroy(gameObject);

        TocarMusica(musica);
    }


    [SerializeField] private SFX sFX;
    [System.Serializable]
    public class SFX
    {
        public Jogador jogador;
        [System.Serializable]
        public class Jogador
        {
            public AudioClip Andar => andar;
            [SerializeField] private AudioClip andar;
        }

        public Ambiente ambiente;
        [System.Serializable]
        public class Ambiente
        {
            public AudioClip Bloco => bloco;
            [SerializeField] private AudioClip bloco;
        }

        public Inimigo inimigo;
        [System.Serializable]
        public class Inimigo
        {
            public AudioClip Andar => andar;
            [SerializeField] private AudioClip andar;
        }
    }

    static public void TocarSFX(AudioClip sfx)
    => instance._TocarSFX(sfx);
    private void _TocarSFX(AudioClip sfx)
    => audioSource.PlayOneShot(sfx);



    static public void TocarMusica(AudioClip sfx)
    => instance._TocarMusica(sfx);
    private void _TocarMusica(AudioClip musica)
    {
        audioSource.clip = musica;
        audioSource.Play();
    }

    static public void PararMusica()
    => instance._PararMusica();
    private void _PararMusica()
    {
        audioSource.clip = null;
    }
}
