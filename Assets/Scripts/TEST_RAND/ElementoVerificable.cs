// ========================
// Script: ElementoVerificable.cs
// ========================
using UnityEngine;

public class ElementoVerificable : MonoBehaviour
{
    public string nombreElemento;
    public bool estaCorrecto = false; // Estado actual

    public void ConfigurarEstado(bool esCorrecto)
    {
        estaCorrecto = esCorrecto;
    }

    public bool EstaCorrecto()
    {
        return estaCorrecto;
    }
}
