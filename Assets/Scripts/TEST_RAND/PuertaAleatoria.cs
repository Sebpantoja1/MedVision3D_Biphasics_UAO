// ========================
// Script: PuertaAleatoria.cs
// ========================
using UnityEngine;

public class PuertaAleatoria : MonoBehaviour
{
    public GameObject puertaConVisor;
    public GameObject puertaSinVisor;
    public ElementoVerificable elementoVerificable;

    void Start()
    {
        bool usarConVisor = Random.value > 0.5f;
        puertaConVisor.SetActive(usarConVisor);
        puertaSinVisor.SetActive(!usarConVisor);

        if (elementoVerificable != null)
        {
            elementoVerificable.ConfigurarEstado(usarConVisor); // correcto si tiene visor
        }
    }
}
