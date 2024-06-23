using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bau_Radomizer : MonoBehaviour
{
    GameObject item;

    Baus_Controller controller;
    Count_RecargaSombra recarga;

    [SerializeField] GameObject chave;
    public GameObject[] lista = new GameObject[1];

    /*[SerializeField] GameObject bomba;
    [SerializeField] GameObject tabua;
    [SerializeField] GameObject kyrozene;*/

    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<Baus_Controller>();
        recarga = FindObjectOfType<Count_RecargaSombra>();

        lista[0] = chave;
    }

    public IEnumerator AbrirCoroutine(Vector3 direcao)
    {
        // animaçã start (a implementar)
        float timer = 1f;

        // seleciona o item a spawnar
        if (controller.chaveSpawned == false && controller.bausAtivos == 1)
        {
            item = chave;
            controller.chaveSpawned = true;
        }
        else
        {
            int rand;
            if (controller.chaveSpawned == true)
            {
                rand = Random.Range(1, lista.Length);
            }
            else
            {
                rand = Random.Range(0, lista.Length);
            }
            item = lista[rand];
            if (rand == 0)
            {
                controller.chaveSpawned = true;
            }
            
            controller.bausAtivos -= 1;
        }

        do
        {
            timer -= Time.deltaTime;
            yield return null;
        } while (
            // Repete enquanto a animação esta acontecendo (a implementar)
            timer > 0f
        );

        Instantiate(item, transform.position, Quaternion.identity);
        recarga.ConcluirSala();
        Destroy(gameObject);
    }
}
