using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bau_Radomizer : MonoBehaviour
{
    GameObject item;

    Baus_Controller controller;

    [SerializeField] GameObject chave;
    [SerializeField] GameObject bomba;
    [SerializeField] GameObject tabua;
    [SerializeField] GameObject kyrozene;

    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<Baus_Controller>();
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
                rand = Random.Range(1, 4);
            }
            else
            {
                rand = Random.Range(0, 4);
            }
            switch (rand)
            {
                case 0:
                    item = chave;
                    controller.chaveSpawned = true;
                    break;
                case 1:
                    item = bomba;
                    break;
                case 2:
                    item = tabua;
                    break;
                case 3:
                    item = kyrozene;
                    break;
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
        Destroy(gameObject);
    }
}
