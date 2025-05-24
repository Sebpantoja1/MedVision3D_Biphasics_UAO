// ========================
// Script: GeneradorMedidasQuirófano.cs
// ========================
using UnityEngine;
using TMPro;

public class GeneradorMedidasQuirófano : MonoBehaviour
{
    public TextMeshProUGUI largoTexto;
    public TextMeshProUGUI anchoTexto;
    public TextMeshProUGUI altoTexto;

    public ElementoVerificable largoEval;
    public ElementoVerificable anchoEval;
    public ElementoVerificable altoEval;

    void Start()
    {
        float largo = Random.Range(4f, 6.5f);
        float ancho = Random.Range(3f, 5.5f);
        float alto  = Random.Range(2.5f, 3.5f);

        largoTexto.text = largo.ToString("F1") + " m";
        anchoTexto.text = ancho.ToString("F1") + " m";
        altoTexto.text  = alto.ToString("F1") + " m";

        largoEval.ConfigurarEstado(largo >= 5f);
        anchoEval.ConfigurarEstado(ancho >= 4f);
        altoEval.ConfigurarEstado(alto >= 3f);
    }
}
