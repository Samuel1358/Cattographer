using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Freckles_Escavar : MonoBehaviour
{
    public GameObject[] linhaA = new GameObject[7];
    public GameObject[] linhaB = new GameObject[7];
    public GameObject[] linhaC = new GameObject[7];
    public GameObject[] linhaD = new GameObject[7];
    public GameObject[] linhaE = new GameObject[7];

    private GameObject[][] escavaveis = new GameObject[5][];

    public Empurrao[] blocos = new Empurrao[4];

    [SerializeField] int estado = 0;
    [SerializeField] int contagem;
    int linha = 2, coluna = 3;
    int projeteis = 3;

    public float timerBuraco = 4f, timerAtaque = 5f, timerMover = 3f;
    float ttBuraco, ttAtaque, ttMover;
    float timerArremesso, ttArremesso;

    private float timerAniEntrar = 2f, ttAniEntrar;

    // Start is called before the first frame update
    void Start()
    {
        escavaveis = new GameObject[5][] { linhaA, linhaB, linhaC, linhaD, linhaE };

        contagem = linhaA.Length * escavaveis.Length;

        ttBuraco = timerBuraco;
        ttAtaque = timerAtaque;
        timerArremesso = ttAtaque / 4;
        ttArremesso = timerArremesso;
        ttMover = timerMover;
        ttAniEntrar = timerAniEntrar;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < blocos.Length; i++)
        {
            blocos[i].Queda();
        }

        switch (estado)
        {
            case 0:
                if (Cavar(escavaveis[2][3]))
                {
                    estado = 3;
                    Sortiar();
                }
                else
                {
                    // deu sinal
                    escavaveis[2][3].transform.eulerAngles = new Vector3(0f, escavaveis[linha][coluna].transform.rotation.eulerAngles.y + 0.5f, 0f);
                }
                break;
            case 1:
                if (Mover())
                {
                    estado = 2;
                }
                else
                {
                    /*if (Entrar())
                    {

                    }*/
                }
                break;
            case 2:
                if (Cavar(escavaveis[linha][coluna]))
                {
                    if (contagem <= 0)
                    {
                        estado = 4;
                    }
                    else
                    {
                        estado = 3;
                    }
                }
                else
                {           
                    // deu sinal
                    escavaveis[linha][coluna].transform.eulerAngles = new Vector3(0f, escavaveis[linha][coluna].transform.rotation.eulerAngles.y + 0.5f, 0f);
                }
                break;
            case 3:
                if (Ataque())
                {
                    estado = 1;
                    projeteis = 3;
                    Sortiar();
                    Debug.Log("entrou na terra");
                }
                else
                {
                    if (projeteis > 0)
                    {
                        if (Arremessar())
                        {
                            Debug.Log("atacou " + (3 - projeteis));
                        }
                    }
                }
                break;
            case 4:
                Debug.Log("deu certooo");
                break;
        }
    }



    private bool Cavar(GameObject obj)
    {
        if (timerBuraco <= 0)
        {
            timerBuraco = ttBuraco;
            obj.SetActive(false);
            contagem -= 1;
            return true;
        }
        else
        {
            timerBuraco -= Time.deltaTime;
            return false;
        }
    }

    private bool Mover()
    {
        if (timerMover <= 0)
        {
            timerMover = ttMover;
            return true;
        }
        else
        {
            timerMover -= Time.deltaTime;
            return false;
        }
    }

    private bool Ataque()
    {
        if (timerAtaque <= 0)
        {
            timerAtaque = ttAtaque;
            return true;
        }
        else
        {
            timerAtaque -= Time.deltaTime;
            return false;
        }
    }

    private bool Arremessar()
    {
        if (timerArremesso <= 0)
        {
            timerArremesso = ttArremesso;

            projeteis -= 1;
            return true;
        }
        else
        {
            timerArremesso -= Time.deltaTime;
            return false;
        }
    }



    private bool Entrar(float timer, float tt)
    {
        if (timerAniEntrar <= 0)
        {
            timerAniEntrar = ttAniEntrar;
            return true;
        }
        else
        {
            timerAniEntrar -= Time.deltaTime;
            return false;
        }
    }



    private void Sortiar()
    {
        while (true)
        {
            linha = Random.Range(0, 5);
            coluna = Random.Range(0, 7);

            #pragma warning disable CS0618 // O tipo ou membro é obsoleto
            if (escavaveis[linha][coluna].active == true)
            {
                break;
            }
        }
    }
}
