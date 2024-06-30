using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class SetEmissão : MonoBehaviour
{
    public string hex;

    // Start is called before the first frame update
    void Start()
    {
        var meshRenderer = GetComponent<MeshRenderer>();
        var material = meshRenderer.material;

        if (ColorUtility.TryParseHtmlString(hex, out Color cor))
        {
            material.SetColor("_EmissionColor", cor);
        }
    }
}
