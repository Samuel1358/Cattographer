using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chester : MonoBehaviour
{
    [SerializeField] private float velocidade = 5;
    [SerializeField] private float cooldownPulo = 2;
    [SerializeField] private float tempoAtordoado = 1;
    [SerializeField] private float alturaBlocos = 5;
    [SerializeField] private float tempoQuedaBlocos = 1;
    [SerializeField] private float raioEmpurrao = 1;

    [SerializeField] private List<Empurrao> blocosAfetados;

    private float defaultY;
    private void Start()
    {
        defaultY = transform.position.y;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Mov_Player player = FindObjectOfType<Mov_Player>();
            Vector3 alvo = new(
                player.transform.position.x,
                defaultY,
                player.transform.position.z
            );
            Pular(alvo);
        }
    }

    bool pulando = false;
    private void Pular(Vector3 alvo)
    {
        if (!pulando)
        { StartCoroutine(PuloCoroutine(alvo)); }
    }

    private IEnumerator PuloCoroutine(Vector3 alvo)
    {
        pulando = true;

        // corrige a posição conforme o grid
        Vector3 direcao = alvo - transform.position;
        alvo = new(
            Mathf.Round(alvo.x) - Mathf.Sign(direcao.x) * .5f,
            Mathf.Round(alvo.y),
            Mathf.Round(alvo.z) - Mathf.Sign(direcao.z) * .5f
        );

        yield return Utilitarios.Parabola(gameObject, transform.position, 1, 0.6f);

        float distanciaDoPulo = (alvo - transform.position).magnitude;
        float tempoDoPulo = distanciaDoPulo / velocidade;
        foreach (var bloco in blocosAfetados)
        {
            Vector3 distanciaBloco = Utilitarios.IgnoreY(bloco.transform.position - alvo);
            Vector3 offset = Vector3.zero;
            Vector3 movimentoBloco;

            if (Mathf.Abs(distanciaBloco.x) <= raioEmpurrao && Mathf.Abs(distanciaBloco.z) <= raioEmpurrao)
            {
                movimentoBloco = Vector3.right * Mathf.Sign(distanciaBloco.x);
                if (Mathf.Abs(distanciaBloco.x) <= raioEmpurrao && !bloco.MovimentoObstruido(movimentoBloco))
                { offset += movimentoBloco; }

                movimentoBloco = Vector3.forward * Mathf.Sign(distanciaBloco.z);
                if (Mathf.Abs(distanciaBloco.z) <= raioEmpurrao && !bloco.MovimentoObstruido(movimentoBloco))
                { offset += movimentoBloco; }
            }

            bloco.Pula(offset, alturaBlocos, tempoDoPulo + tempoQuedaBlocos);
        }

        yield return Utilitarios.Parabola(gameObject, alvo, 2, tempoDoPulo);

        yield return TempoIndefeso();

        pulando = false;
    }

    private float tempoIndefesoRestante = 0;
    private IEnumerator TempoIndefeso()
    {
        tempoIndefesoRestante = cooldownPulo;
        while (tempoIndefesoRestante > Time.deltaTime)
        {
            tempoIndefesoRestante -= Time.deltaTime;
            yield return null;
        }
        tempoIndefesoRestante = 0;
    }
    public bool IsIndefeso => tempoIndefesoRestante > 0;

    private void LevarDano()
    {
        tempoIndefesoRestante += tempoAtordoado;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (tempoIndefesoRestante > 0)
        {
            if (other.CompareTag("Empurravel"))
            {
                LevarDano();
                blocosAfetados.RemoveAll(bloco => bloco.gameObject == other.gameObject);
                Destroy(other.gameObject, 0.5f);
            }
        }
    }
}
