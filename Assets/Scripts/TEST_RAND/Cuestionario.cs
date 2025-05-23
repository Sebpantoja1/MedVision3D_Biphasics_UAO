using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class Cuestionario : MonoBehaviour
{
    [System.Serializable]
    public class Pregunta
    {
        public ElementoVerificable elemento;
        public Toggle toggleRespuesta; // Toggle que representa la respuesta del usuario
    }

    public List<Pregunta> preguntas;
    public TextMeshProUGUI resultadoTexto;

    public void EvaluarCuestionario()
    {
        int puntaje = 0;
        int total = preguntas.Count;

        foreach (var pregunta in preguntas)
        {
            bool estadoReal = pregunta.elemento.EstaCorrecto();
            bool respuestaUsuario = pregunta.toggleRespuesta.isOn;

            if (estadoReal == respuestaUsuario)
            {
                puntaje++;
            }
        }

        resultadoTexto.text = $"Puntaje: {puntaje} / {total}";
    }
}
