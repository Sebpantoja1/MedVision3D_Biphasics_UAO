using UnityEngine;

public class ControlCanvasIntro : MonoBehaviour
{
    public GameObject canvasActual;
    public GameObject canvasSiguiente;
    public float duracionIntro = 8f; // segundos antes de ocultar automáticamente

    void Start()
    {
        StartCoroutine(EsperarYContinuar());
    }

    private System.Collections.IEnumerator EsperarYContinuar()
    {
        yield return new WaitForSeconds(duracionIntro);
        canvasActual.SetActive(false);
        if (canvasSiguiente != null)
            canvasSiguiente.SetActive(true);
    }
}