using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class MenuCanvas : MonoBehaviour
{
    public CanvasGroup canvasGrupo; // Asigna el grupo de todos los elementos del menú
    public RectTransform panelTransform; // El contenedor del cuadro + botones
    public float duracion = 1.2f;
    public float desplazamientoY = 0.5f; // Distancia desde arriba
    public string mainScene;
    public GameObject canvasActual;
    public GameObject canvasSig; 
    private Vector2 posicionFinal;
    

    public void Start()
    {
        // Guardar la posición final
        posicionFinal = panelTransform.anchoredPosition;

        // Empezamos con transparencia y más arriba
        panelTransform.anchoredPosition = posicionFinal + new Vector2(0f, desplazamientoY);
        canvasGrupo.alpha = 0f;
        //panelTransform.anchoredPosition += Vector2.up * desplazamientoY;

        // Inicia la animación
        StartCoroutine(AnimarEntrada());
    }

    IEnumerator AnimarEntrada()
    {
        float tiempo = 0f;
        Vector2 posicionInicial = panelTransform.anchoredPosition;
        //Vector2 posicionFinal = posicionInicial - Vector2.up * desplazamientoY;

        while (tiempo < duracion)
        {
            float t = tiempo / duracion;
            canvasGrupo.alpha = Mathf.Lerp(0f, 1f, t);
            panelTransform.anchoredPosition = Vector2.Lerp(posicionInicial, posicionFinal, t);
            tiempo += Time.deltaTime;
            yield return null;
        }

        canvasGrupo.alpha = 1f;
        panelTransform.anchoredPosition = posicionFinal;
    }

    public void EscenaJuego()
    {
        SceneManager.LoadScene(mainScene);

    }

    public void KillCanvas()
    {
        canvasActual.SetActive(false);
        canvasSig.SetActive(true); 

    }

 
}
