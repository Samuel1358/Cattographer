using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Timer : MonoBehaviour
{
    [SerializeField] private Animator animator;

    Timer_Sombra sombra;
    public float dano = 1f;

    // Start is called before the first frame update
    void Start()
    {
        sombra = FindObjectOfType<Timer_Sombra>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Inimigo"))
        {
            CausarDano(dano);
        }
    }

    public void CausarDano(float dano)
    {
        animator.SetTrigger("TomarDano");
        sombra.timerSombra -= dano;
    }
}
