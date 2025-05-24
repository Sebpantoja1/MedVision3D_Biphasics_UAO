// ========================
// Script: RandomizadorDeObjetos.cs
// ========================
using UnityEngine;
using System.Collections.Generic;

public class RandomizadorDeObjetos : MonoBehaviour
{
    [System.Serializable]
    public class ObjetoRandomizable
    {
        public GameObject objeto;
        public List<Transform> posiblesPosiciones;
        public bool puedeDesaparecer;
        public ElementoVerificable elementoVerificable; // Para evaluación
    }

    public List<ObjetoRandomizable> objetos;

    public void EjecutarAleatoriedad()
    {
        foreach (var item in objetos)
        {
            // Desaparición aleatoria si está habilitada
            bool activo = true;
            if (item.puedeDesaparecer && Random.value < 0.5f)
            {
                item.objeto.SetActive(false);
                activo = false;

                if (item.elementoVerificable != null)
                    item.elementoVerificable.ConfigurarEstado(false); // No cumple si desaparece
            }

            // Si está activo, moverlo a una posición aleatoria
            if (activo && item.posiblesPosiciones.Count > 0)
            {
                int index = Random.Range(0, item.posiblesPosiciones.Count);
                item.objeto.transform.position = item.posiblesPosiciones[index].position;
                item.objeto.SetActive(true);

                // Si está vinculado a evaluación, podemos decir que la posición 0 es la "correcta"
                if (item.elementoVerificable != null)
                {
                    bool esCorrecta = (index == 0);
                    item.elementoVerificable.ConfigurarEstado(esCorrecta);
                }
            }
        }
    }
}
