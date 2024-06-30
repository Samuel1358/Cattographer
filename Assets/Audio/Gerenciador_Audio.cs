using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Gerenciador_Audio : MonoBehaviour
{
    static private Gerenciador_Audio instance;

    [SerializeField] private AudioClip musica;
    [SerializeField] private bool ApenasUmaVez;

    [SerializeField] private AudioSource gerenciadorMusicas;
    [SerializeField] private AudioSource gerenciadorSFX;
    [SerializeField] private AudioMixer audioMixer;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            TocarPredefinida();
        }
        else
        {
            instance.musica = musica;
            TocarPredefinida();
            Destroy(gameObject);
        }
    }

    /*
    [SerializeField] private SFX _SFX;
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
    */

    static public void TocarSFX(AudioClip sfx)
    => instance._TocarSFX(sfx);
    private void _TocarSFX(AudioClip sfx)
    => gerenciadorSFX.PlayOneShot(sfx);


    static public void TocarPredefinida()
    => instance._TocarPredefinida();
    private void _TocarPredefinida()
    {
        if (ApenasUmaVez) TocarMusicaUmaVez(musica);
        else TocarMusicaEmLoop(musica);
    }

    static public void TocarMusicaUmaVez(AudioClip musica)
    => instance._TocarMusicaUmaVez(musica);
    private void _TocarMusicaUmaVez(AudioClip musica)
    {
        gerenciadorMusicas.loop = false;
        gerenciadorMusicas.clip = musica;
        gerenciadorMusicas.Play();
    }

    static public void TocarMusicaEmLoop(AudioClip musica)
    => instance._TocarMusicaDeFundo(musica);
    private void _TocarMusicaDeFundo(AudioClip musica)
    {
        if (gerenciadorMusicas.clip == musica && gerenciadorMusicas.isPlaying) return;

        gerenciadorMusicas.loop = true;
        gerenciadorMusicas.clip = musica;
        gerenciadorMusicas.Play();
    }

    static public void PararMusica()
    => instance._PararMusica();
    private void _PararMusica()
    { gerenciadorMusicas.Stop(); }

    static public void Volume(float valor)
    => instance._Volume(valor);
    private void _Volume(float valor)
    {
        // o humano escuta em uma escala logarítmica
        // a conta abaixo converte o valor linear para a escala humana
        float valorHumano = Mathf.Log10(valor) * 20;

        audioMixer.SetFloat("Volume", valorHumano);
    }
}
