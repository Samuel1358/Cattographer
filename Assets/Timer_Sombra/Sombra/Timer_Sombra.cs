using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer_Sombra : MonoBehaviour
{
    Gerenciador_Fase fase;

    public float timerSombra = 20f, ttSombra, taxaQueda = 1f;
    public bool active = true, ivencivel = false;

    // Start is called before the first frame update
    void Start()
    {
        // resgate das infos do gride anterior(caso tenha)
        fase = FindObjectOfType<Gerenciador_Fase>();

        timerSombra = fase.timerSombra;
        ttSombra = fase.maxSombra;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerSombra <= 0)
        {
            SceneManager.LoadScene("Lose");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (timerSombra > 0)
        {
            if (active == true && ivencivel == false)
            {
                timerSombra -= Time.deltaTime * taxaQueda * 0.1f;
            }
        }
    }
}
