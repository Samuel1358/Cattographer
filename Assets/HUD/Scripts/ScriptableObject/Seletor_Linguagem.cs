using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LinguageManager")]
public class Seletor_Linguagem : ScriptableObject
{
    public enum Linguagem
    {
        Ingles,
        Portugues,
        Espanhol,
        Italiano,
        Frances,
        Alemao,
        Russo,
    }

    public Linguagem lingua;
}
