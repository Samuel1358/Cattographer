using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static Mov_Inimigo_PassoAPasso;

public class Mov_Player : MonoBehaviour
{
    // MOVE
    //Rigidbody rb;
    //private float spd = 1f;
    public bool canMove = true;
    public bool caiuBuraco = false;
    private float timerMove;
    static private readonly float moveCooldown = 0.16f;

    private int movX = 0, movZ = 0;

    // RAY
    RaycastHit hit;
    public LayerMask bloqueio;
    public LayerMask fundo;
    public LayerMask chao;

    public int sala;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();

        timerMove = moveCooldown;
    }

    void Update()
    {
        #region // MOVE
        // (movimentacao em gride, quadrado por quadrado, com timer para movimenta��o [precionando o bot�o uma vez de cada ou segurando])
        // (o player vira para a dire��o desejada e ent�o se movimenta [importante para o sistema de colis�o de Raycast])

        if (canMove == true)
        {
            if (timerMove <= 0f)
            {
                /*float xInput = Input.GetAxisRaw("Horizontal");
                float zInput = Input.GetAxisRaw("Vertical");*/
                float xInput = movX;
                float zInput = movZ;
                movX = 0;
                movZ = 0;          
                
                if (xInput != 0 || zInput != 0)
                {
                    // Prioriza o eixo X para movimentar somente em um eixo por vez
                    if (xInput != 0) { zInput = 0; }

                    Vector3 direction = new Vector3(xInput, 0, zInput);
                    Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);

                    transform.rotation = rotation;
                    StartCoroutine(MovimentacaoCoroutine(direction));
                    timerMove = moveCooldown;

                }
            }

            if (timerMove > 0f)
            {
                timerMove -= Time.deltaTime;
            }
        }

        #endregion

        /*if (Physics.Raycast(new Ray(transform.position, -transform.up), out _, 1f, chao))
        {
            canMove = true;
        }
        else
        {
            canMove = false;
        }*/

        #region // TECLADO

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Cima();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Direita();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Baixo();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Esquerda();
        }
        

        #endregion
    }

    private IEnumerator MovimentacaoCoroutine(Vector3 direcao)
    {
        canMove = false;

        // For�a a dire��o a ter magnitude 1
        direcao.Normalize();

        // Come�a assumindo que o movimento n�o est� obstru�do
        bool movimentoObstruido = false;

        // Loop para caso o piso seja de gelo
        do
        {
            // Verifica se existe um obst�culo na dire��o do movimento, uma casa a frente
            if (Physics.Raycast(
                ray: new Ray(transform.position, direcao),
                hitInfo: out RaycastHit obstaculo,
                maxDistance: 1f,
                layerMask: bloqueio,
                QueryTriggerInteraction.Collide
            ))
            {
                // Se for uma parede, obstrui o movimento
                if (obstaculo.collider.CompareTag("Parede"))
                {
                    movimentoObstruido = true;
                }
                // Se for um bloco, tenta empurr�-lo
                else if (obstaculo.collider.CompareTag("Empurravel"))
                {
                    Empurrao bloco = obstaculo.collider.GetComponent<Empurrao>();
                    bool conseguiuEmpurrar = bloco.Empurrar(direcao);

                    // Se n�o conseguiu empurrar, obstrui o movimento
                    movimentoObstruido = !conseguiuEmpurrar;
                }
            }

            // Se n�o for obstru�do, movimenta
            if (!movimentoObstruido)
            {
                transform.position += direcao;

                // Queda no buraco
                if (Physics.Raycast(new Ray(transform.position, -transform.up), out _, 23f, chao))
                {
                    
                }
                else
                {
                    if (Physics.Raycast(new Ray(transform.position, -transform.up), out _, 1f))
                    {

                    }
                    else
                    {
                        canMove = false;
                        caiuBuraco = true;
                        yield break;
                    }
                }
            }

            yield return null;            

        } while (
            // Repete enquanto o piso for de gelo e se o movimento n�o estiver obstru�do
            Physics.Raycast(
                ray: new Ray(transform.position, -transform.up),
                hitInfo: out RaycastHit piso,
                maxDistance: 1f,
                layerMask: chao,
                QueryTriggerInteraction.Collide
            ) && piso.collider.CompareTag("Gelo")
            && !movimentoObstruido
        );

        canMove = true;
    }

    #region // GET - botoes

    public void Cima()
    {
        movZ = 1;
    }
    public void Direita()
    {
        movX = 1;
    }
    public void Baixo()
    {
        movZ = -1;
    }
    public void Esquerda()
    {
        movX = -1;
    }

    #endregion
}
