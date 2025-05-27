using UnityEngine;
using System.Collections.Generic;

public class GrupoVerificable : MonoBehaviour
{
    [System.Serializable]
    public class ObjetoOriginal
    {
        public GameObject objeto;
        public Vector3 posicionOriginal;
    }

    public List<GameObject> objetosDelGrupo = new List<GameObject>();

    private List<ObjetoOriginal> referenciasOriginales = new List<ObjetoOriginal>();

    void Start()
    {
        foreach (var obj in objetosDelGrupo)
        {
            if (obj != null)
            {
                referenciasOriginales.Add(new ObjetoOriginal
                {
                    objeto = obj,
                    posicionOriginal = obj.transform.position
                });
            }
        }
    }

    public bool GrupoCorrecto()
    {
        foreach (var referencia in referenciasOriginales)
        {
            if (referencia.objeto == null) return false;

            float distancia = Vector3.Distance(referencia.objeto.transform.position, referencia.posicionOriginal);
            if (distancia > 0.05f) return false; // margen de error permisible
        }

        return true;
    }

    public List<string> ObtenerErrores()
    {
        List<string> errores = new List<string>();

        foreach (var referencia in referenciasOriginales)
        {
            if (referencia.objeto == null)
            {
                errores.Add("Objeto eliminado");
                continue;
            }

            float distancia = Vector3.Distance(referencia.objeto.transform.position, referencia.posicionOriginal);
            if (distancia > 0.05f)
            {
                errores.Add($"{referencia.objeto.name} fue movido");
            }
        }

        return errores;
    }
}
