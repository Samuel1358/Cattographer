using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer_Dungeon : MonoBehaviour
{
    public float timerDD = 60f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerDD <= 0)
        {
            SceneManager.LoadScene(3);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (timerDD > 0)
        {
            timerDD -= Time.deltaTime;
        }
    }
}
