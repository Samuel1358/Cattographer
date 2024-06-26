using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chester_Blocos : MonoBehaviour
{
    [SerializeField] Chester chester;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Hit_Timer>().CausarDano(1f);
            chester.DestroiBloco(gameObject);
        }
    }
}
