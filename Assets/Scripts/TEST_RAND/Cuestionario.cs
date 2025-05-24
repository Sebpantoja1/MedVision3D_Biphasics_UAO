using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class Cuestionario : MonoBehaviour
{
    [System.Serializable]
    public class Pregunta
    {
        public string nombreElemento;              // Nombre legible del elemento (para mostrar en la retroalimentación)
        public ElementoVerificable elemento;       // Componente que contiene la verificación
        public Toggle toggleRespuesta;             // Respuesta seleccionada por el usuario
    }

    public List<Pregunta> preguntas;
    public TextMeshProUGUI resultadoTexto;
    public TextMeshProUGUI retroalimentacionTexto; // Texto donde se mostrarán los errores
    public GameObject canvasRetroalimentacion;     // Canvas que muestra la retroalimentación
    public GameObject canvasCuestionario; // CuestionarioKill

    public void EvaluarCuestionario()
    {
        int puntaje = 0;
        int total = preguntas.Count;
        List<string> errores = new List<string>();

        foreach (var pregunta in preguntas)
        {
            bool estadoCorrecto = pregunta.elemento.EstaCorrecto();
            bool respuestaUsuario = pregunta.toggleRespuesta.isOn;

            if (estadoCorrecto == respuestaUsuario)
            {
                puntaje++;
            }
            else
            {
                errores.Add($"❌ {pregunta.nombreElemento} — Estado incorrecto.");
            }
        }

        resultadoTexto.text = $"Puntaje: {puntaje} / {total}";

        if (errores.Count == 0)
        {
            retroalimentacionTexto.text = "🎉 ¡Excelente! Todos los elementos fueron verificados correctamente.";
        }
        else
        {
            retroalimentacionTexto.text = "🔍 Elementos con error:\n\n" + string.Join("\n", errores);
        }

        MostrarRetroalimentacion();
    }

    void MostrarRetroalimentacion()
    {
        canvasRetroalimentacion.SetActive(true);
        canvasCuestionario.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f; // Detiene el juego si lo deseas
    }

    public void Finalizar()
    {
        // Opcional: recargar escena o cerrar canvas
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
