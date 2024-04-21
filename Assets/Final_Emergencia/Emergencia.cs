using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Emergencia : MonoBehaviour
{
    Player_Final player;
    public float timerFinal = 40f;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player_Final>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.fuga == true)
        {
            if (timerFinal <= 0)
            {
                SceneManager.LoadScene(3);
            }
            if (timerFinal > 0)
            {
                timerFinal -= Time.deltaTime;
            }
        }
    }
}
