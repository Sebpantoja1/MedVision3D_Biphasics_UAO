using UnityEngine;
using TMPro;
using System.Collections;



public class MissionPanelController : MonoBehaviour
{
    public CanvasGroup panelGroup;         // El panel que se desliza
    public TextMeshProUGUI mensajeTexto;   // El componente de texto

    public string mensajeInicial = "Disfruta la vista, comienza por explorar libremente con las teclas WASD el entorno y halla los puntos de interés iluminados.";
    public string mensajePosterior = "Dirígete hacia uno de los puntos de interés para obtener más información.";

    void Start()
    {
        // Configurar mensaje inicial
        mensajeTexto.text = mensajeInicial;

        // Animar entrada desde la izquierda
        panelGroup.alpha = 1f;
        RectTransform rt = panelGroup.GetComponent<RectTransform>();
        Vector2 fueraDePantalla = new Vector2(-Screen.width, rt.anchoredPosition.y);
        rt.anchoredPosition = fueraDePantalla;
        LeanTween.moveX(rt, 0f, 1f).setEaseOutCubic();

        // Iniciar coroutine para cambiar texto y luego desaparecer panel
        StartCoroutine(ProcesoMensaje());
    }

    IEnumerator ProcesoMensaje()
    {
        yield return new WaitForSeconds(5f);
        mensajeTexto.text = mensajePosterior;

        // Forzar actualización de layout si usas Content Size Fitter
        // LayoutRebuilder.ForceRebuildLayoutImmediate(panelGroup.GetComponent<RectTransform>());

        // Esperar 7 segundos con el mensaje posterior visible
        yield return new WaitForSeconds(7f);

        // Hacer fade out del panel en 1 segundo y luego desactivarlo
        LeanTween.alphaCanvas(panelGroup, 0f, 1f).setOnComplete(() =>
        {
            panelGroup.gameObject.SetActive(false);
        });
    }
}
