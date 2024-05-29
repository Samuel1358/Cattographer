using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer_Sombra : MonoBehaviour
{
    public float timerSombra = 20f, ttSombra, taxaQueda = 1f;
    public bool active = true;

    // Start is called before the first frame update
    void Start()
    {

        ttSombra = timerSombra;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerSombra <= 0)
        {
            SceneManager.LoadScene(3);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (timerSombra > 0)
        {
            if (active == true)
            {
                timerSombra -= Time.deltaTime * taxaQueda * 0.1f;
            }
        }
    }
}
