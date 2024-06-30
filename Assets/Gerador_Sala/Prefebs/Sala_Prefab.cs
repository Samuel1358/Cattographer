using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sala_Prefab : MonoBehaviour
{
    public Sala_Controller controller;

    public Gride.Sala_Def definicao;
    private void Start()
    {
        controller.definicao = definicao;
    }

    public GameObject Create(Gride.Sala_Def definicao, Vector3 posicao, Quaternion rotacao)
    {
        Sala_Prefab instance = Instantiate(this, posicao, rotacao * Quaternion.Euler(0f, definicao.RotacaoEmGraus, 0f) * transform.rotation);
        instance.definicao = definicao;
        return instance.gameObject;
    }

}
