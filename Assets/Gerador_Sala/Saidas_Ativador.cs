using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Saidas_Ativador : MonoBehaviour
{
    public Sala_Controller controller;

    public bool playerPassed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // (verifica se o player entrou por esta porta)
        if (other.CompareTag("Player") && controller.spawnSeted == false)
        {
            playerPassed = true;
        }
    }
}
