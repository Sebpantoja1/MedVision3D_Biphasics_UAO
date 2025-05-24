// ========================
// Script: TermohigrometroRandom.cs
// ========================
using UnityEngine;
using TMPro;

public class TermohigrometroRandom : MonoBehaviour
{
    public TextMeshProUGUI temperaturaTexto;
    public ElementoVerificable temperaturaEval;

    void Start()
    {
        float temperatura = Random.Range(15f, 30f);
        temperaturaTexto.text = temperatura.ToString("F1") + " °C";
        temperaturaEval.ConfigurarEstado(temperatura >= 20f && temperatura <= 25f);
    }
}
