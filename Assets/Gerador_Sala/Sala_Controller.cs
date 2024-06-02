using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sala_Controller : MonoBehaviour
{
    static private Sala_Controller salaAtual;
    static private Saidas_Ativador ultimaPorta;
    static private Mov_Player player;
    
    private const float spawnHeight = 1.5f;

    public Gride.Sala_Def definicao;

    // Start is called before the first frame update
    void Start()
    {
        /*#region // SAIDAS

        switch (infos[1])
        {
            case 1:
                //@
                break;
            case 2:
                //@
                break;
            case 3:
                //@
                break;
            case 4:
                //@
                break;
            case 5:
                //@
                break;
        }

        #endregion*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player != null)
        {
            if (other.CompareTag("Player"))
            {
                salaAtual = this;
                Camera_Player.Reposicionar(transform.position);
            }
        }
    }

    static public IEnumerator RespawnPlayerCoroutine()
    {
        // (manda o player spawnar na saida pelo qual ele entrou)
        yield return player.SpawnCoroutine(ultimaPorta.transform.position + new Vector3(0, spawnHeight, 0));
    }

    static public Sala_Controller SalaAtual => salaAtual;
    static public void SetPlayer(Mov_Player player)
    { Sala_Controller.player = player; }

    static public void SetUltimaPorta(Saidas_Ativador porta)
    { ultimaPorta = porta; }

    public Saidas_Ativador GetUltimaPorta()
    {
        return ultimaPorta;
    }
}
