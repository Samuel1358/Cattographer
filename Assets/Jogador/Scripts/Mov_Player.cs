using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mov_Player : MonoBehaviour
{
    // MOVE
    //Rigidbody rb;
    float spd = 1f;
    Quaternion dir;
    public bool canMove = true, caiuBuraco = false;
    float timerMove = 0.2f, ttMove;

    // RAY
    RaycastHit hit;
    public LayerMask bloqueio;
    public LayerMask fundo;

    public int sala;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();

        ttMove = timerMove;
    }

    // Update is called once per frame
    void Update()
    {
        #region // MOVE
        // (movimentacao em gride, quadrado por quadrado, com timer para movimentação [precionando o botão uma vez de cada ou segurando])
        // (o player vira para a direção desejada e então se movimenta [importante para o sistema de colisão de Raycast])

        if (canMove == true)
        {
            if (Input.GetKey(KeyCode.UpArrow) && timerMove <= 0f)
            {
                dir = Quaternion.Euler(0f, 0f, 0f);
                transform.rotation = dir;
                Mover(new Vector3(transform.position.x, transform.position.y, transform.position.z + spd));
                timerMove = ttMove;
                //transform.position = new Vector3(0f, 2f, -7f);
            }
            if (Input.GetKey(KeyCode.RightArrow) && timerMove <= 0f)
            {
                dir = Quaternion.Euler(0f, 90f, 0f);
                transform.rotation = dir;
                Mover(new Vector3(transform.position.x + spd, transform.position.y, transform.position.z));
                timerMove = ttMove;
            }
            if (Input.GetKey(KeyCode.DownArrow) && timerMove <= 0f)
            {
                dir = Quaternion.Euler(0f, 180f, 0f);
                transform.rotation = dir;
                Mover(new Vector3(transform.position.x, transform.position.y, transform.position.z - spd));
                timerMove = ttMove;
            }
            if (Input.GetKey(KeyCode.LeftArrow) && timerMove <= 0f)
            {
                dir = Quaternion.Euler(0f, 270f, 0f);
                transform.rotation = dir;
                Mover(new Vector3(transform.position.x - spd, transform.position.y, transform.position.z));
                timerMove = ttMove;
            }

            if (timerMove > 0f)
            {
                timerMove -= Time.deltaTime;
            }
        }

        #endregion
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Buraco"))
        {
            // (não pode se mexer se cair no buraco)
            if (Physics.Raycast(new Ray(transform.position, transform.up * -1f), out hit, 1f, bloqueio, QueryTriggerInteraction.Collide))
            {
               
            }
            else
            {
                canMove = false;
                caiuBuraco = true;
            }
        }
    }

    private void Mover(Vector3 mover)
    {
        // (verifica se há um grupo de mais de um obstáculo a frente do jogador)
        // (se houver, ele não anda)

        if (Physics.RaycastAll(new Ray(transform.position, transform.forward), 2f, bloqueio, QueryTriggerInteraction.Collide).Length > 1)
        {
            // (verifica se está passando por uma porta que conecta uma sala a outra)
            if (Physics.Raycast(new Ray(transform.position, transform.forward), out hit, 1f, bloqueio, QueryTriggerInteraction.Collide))
            {
                if (hit.collider.CompareTag("LimitadorSala"))
                {
                    transform.position = new Vector3(Mathf.Round(mover.x), mover.y, Mathf.Round(mover.z));
                }
            }
        }
        else
        {
            // (verifica se há uma pareda a frente do jogador)
            if (Physics.Raycast(new Ray(transform.position, transform.forward), out hit, 1f, bloqueio, QueryTriggerInteraction.Collide))
            {
                if (hit.collider.CompareTag("Parede"))
                {

                }
                else
                {
                    transform.position = new Vector3(Mathf.Round(mover.x), mover.y, Mathf.Round(mover.z));
                }
            }
            else
            {
                transform.position = new Vector3(Mathf.Round(mover.x), mover.y, Mathf.Round(mover.z));
            }
        }
    }
}
