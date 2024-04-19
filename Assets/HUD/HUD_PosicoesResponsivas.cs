using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HUD_PosicoesResponsivas : MonoBehaviour
{
    public RectTransform canvas;

    public RectTransform botoes_move;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region // botoes_move

        botoes_move.anchorMin = new Vector2(0.5f, 0.5f);
        botoes_move.anchorMax = new Vector2(0.5f, 0.5f);
        botoes_move.pivot = new Vector2(0.5f, 0.5f);
        Debug.Log(canvas.rect.height);
        Debug.Log(canvas.rect.height / 2460);
        botoes_move.anchoredPosition = new Vector2(0, -880 * (canvas.rect.height / 2460));

        #endregion
    }
}
