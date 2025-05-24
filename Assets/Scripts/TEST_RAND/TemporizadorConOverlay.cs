using UnityEngine;
using TMPro;  // Importante para TextMeshPro

public class TemporizadorConOverlay : MonoBehaviour
{
    public float tiempoDuracionEnSegundos = 300f; // Ej: 5 minutos
    public GameObject canvasCuestionario;         // Canvas del cuestionario a mostrar
    public GameObject canvasTemporizador;         // Canvas donde está el TMP
    public TextMeshProUGUI textoTemporizador;     // Texto TMP para mostrar el tiempo

    private bool cronometroActivo = false;
    private float tiempoRestante;

    void Start()
    {
        canvasCuestionario.SetActive(false);
        if (canvasTemporizador != null)
            canvasTemporizador.SetActive(false);
    }

    void Update()
    {
        if (!cronometroActivo) return;

        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante <= 0f)
        {
            tiempoRestante = 0f;
            cronometroActivo = false;
            MostrarCuestionario();
        }

        if (textoTemporizador != null)
        {
            int minutos = Mathf.FloorToInt(tiempoRestante / 60);
            int segundos = Mathf.FloorToInt(tiempoRestante % 60);
            textoTemporizador.text = $"{minutos:00}:{segundos:00}";
        }
    }

    public void IniciarTemporizador()
    {
        tiempoRestante = tiempoDuracionEnSegundos;
        cronometroActivo = true;

        if (canvasTemporizador != null)
            canvasTemporizador.SetActive(true);
    }

    private void MostrarCuestionario()
    {
        if (canvasTemporizador != null)
            canvasTemporizador.SetActive(false);

        canvasCuestionario.SetActive(true);
    }
}
