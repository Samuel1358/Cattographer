using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alavanca : MonoBehaviour
{
    public Reset_Sombra reset;
    Count_RecargaSombra recarga;

    bool acionada = false;

    // Start is called before the first frame update
    void Start()
    {
        recarga = FindObjectOfType<Count_RecargaSombra>();
    }

    public IEnumerator AcionarCoroutine(Vector3 direcao)
    {
        // animaçã start (a implementar)
        /*float timer = 1f;

        do
        {
            timer -= Time.deltaTime;
            yield return null;
        } while (
            // Repete enquanto a animação esta acontecendo (a implementar)
            timer > 0f
        );*/

        reset.DesativarSombra();
        recarga.ConcluirSala();
        acionada = true;
        transform.Rotate(Vector3.up * 180);
        return null;
        //Destroy(gameObject);
    }

    public bool GetAcionada()
    {
        return this.acionada;
    }
}
