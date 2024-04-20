using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HUD_PosicoesResponsivas : MonoBehaviour
{
    public RectTransform canvas;

    public RectTransform timer;
    public RectTransform verdes;
    public RectTransform amarelos;
    public RectTransform botoes_move;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        #region // timer

        /*botoes_move.anchorMin = new Vector2(0f, 1f);
        botoes_move.anchorMax = new Vector2(0f, 1f);
        botoes_move.pivot = new Vector2(0.5f, 0.5f);*/

        timer.anchoredPosition = new Vector2(360 * (canvas.rect.width / 1080), -135 * (canvas.rect.height / 2460));

        #endregion

        #region // verde

        /*botoes_move.anchorMin = new Vector2(1f, 1f);
        botoes_move.anchorMax = new Vector2(1f, 1f);
        botoes_move.pivot = new Vector2(0.5f, 0.5f);*/

        verdes.anchoredPosition = new Vector2(-120 * (canvas.rect.width / 1080), -120 * (canvas.rect.height / 2460));

        #endregion

        #region // amarelo

        /*botoes_move.anchorMin = new Vector2(1f, 1f);
        botoes_move.anchorMax = new Vector2(1f, 1f);
        botoes_move.pivot = new Vector2(0.5f, 0.5f);*/

        amarelos.anchoredPosition = new Vector2(-120 * (canvas.rect.width / 1080), -210 * (canvas.rect.height / 2460));

        #endregion

        #region // botoes_move

        /*botoes_move.anchorMin = new Vector2(0.5f, 0.5f);
        botoes_move.anchorMax = new Vector2(0.5f, 0.5f);
        botoes_move.pivot = new Vector2(0.5f, 0.5f);*/

        botoes_move.anchoredPosition = new Vector2(0, -880 * (canvas.rect.height / 2460));
        
        #endregion
    }
}
