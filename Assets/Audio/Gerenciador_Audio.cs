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


    static public _SFX SFX => instance.sFX;
    [SerializeField] public _SFX sFX;
    [System.Serializable]
    public class _SFX
    {
        [SerializeField] public AudioClip page;

        [SerializeField] public AudioClip fall;
        [SerializeField] public AudioClip slide;
        [SerializeField] public AudioClip magic;

        [SerializeField] public AudioClip cat;
        [SerializeField] public AudioClip step1;
        [SerializeField] public AudioClip step2;
        [SerializeField] public AudioClip collect;
        [SerializeField] public AudioClip revelation;
        [SerializeField] public AudioClip lever;

        [SerializeField] public AudioClip dig;
        [SerializeField] public AudioClip cry;
        [SerializeField] public AudioClip clank;
        [SerializeField] public AudioClip soil;

        [SerializeField] public AudioClip crack;
        [SerializeField] public AudioClip stomp;
    }


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
