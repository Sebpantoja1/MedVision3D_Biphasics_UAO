using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Cuestionario : MonoBehaviour
{
    [System.Serializable]
    public class Pregunta
    {
        public string nombreElemento;              // Nombre legible del elemento o grupo
        public ElementoVerificable elemento;       // Componente individual
        public GrupoVerificable elementos;         // Grupo de objetos
        public Toggle toggleRespuesta;             // Respuesta seleccionada por el usuario
    }

    public List<Pregunta> preguntas;
    public TextMeshProUGUI resultadoTexto;
    public TextMeshProUGUI retroalimentacionTexto;
    public GameObject canvasRetroalimentacion;
    public GameObject canvasCuestionario;
    public GameObject canvasRecept;
    public GameObject canvasBordes;
    public GameObject canvasTermo;
    public GameObject canvasGases;
    public GameObject canvasAlarma;

    public void EvaluarCuestionario()
    {
        int puntaje = 0;
        int total = preguntas.Count;
        List<string> errores = new List<string>();

        foreach (var pregunta in preguntas)
        {
            bool estadoCorrecto = true;

            // 👤 Si es un elemento individual
            if (pregunta.elemento != null)
            {
                estadoCorrecto = pregunta.elemento.EstaCorrecto();
            }
            // 👥 Si es un grupo de elementos
            else if (pregunta.elementos != null)
            {
                estadoCorrecto = pregunta.elementos.GrupoCorrecto();
            }

            bool respuestaUsuario = pregunta.toggleRespuesta.isOn;

            if (estadoCorrecto == respuestaUsuario)
            {
                puntaje++;
            }
            else
            {
                // Obtener detalles de error si es grupo
                if (pregunta.elementos != null)
                {
                    var detalles = pregunta.elementos.ObtenerErrores();
                    foreach (var detalle in detalles)
                    {
                        errores.Add($"❌ {pregunta.nombreElemento} — {detalle}");
                    }
                }
                else
                {
                    errores.Add($"❌ {pregunta.nombreElemento} — Estado incorrecto.");
                }
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
        Time.timeScale = 0f;
    }

    public void NextCanvasRecept()
    {
        canvasRetroalimentacion.SetActive(false);
        canvasRecept.SetActive(true);

    }
    public void NextCanvasAlarma()
    {
        canvasRecept.SetActive(false);
        canvasAlarma.SetActive(true);

    }
    public void NextCanvasBordes()
    {
        canvasAlarma.SetActive(false);
        canvasBordes.SetActive(true);

    }
    public void NextCanvasTermo()
    {
        canvasBordes.SetActive(false);
        canvasTermo.SetActive(true);

    }
    public void NextCanvasGases()
    {
        canvasTermo.SetActive(false);
        canvasGases.SetActive(true);

    }

    public void Finalizar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }
}
