using UnityEngine;

[System.Serializable]
public class ReglaObjeto
{
    public GameObject objeto;
    public Transform[] posiblesPosiciones;
    public bool puedeDesactivarse;
}
public class RandomizadorDeObjetos : MonoBehaviour
{

    public ReglaObjeto[] reglas;

    public void EjecutarAleatoriedad()
    {
        foreach (var regla in reglas)
        {
            if (regla.puedeDesactivarse && Random.value < 0.5f) // 30% chance de desactivar
            {
                //regla.objeto.SetActive(false);
                continue;
            }

            if (regla.posiblesPosiciones != null && regla.posiblesPosiciones.Length > 0)
            {
                int index = Random.Range(0, regla.posiblesPosiciones.Length);
                regla.objeto.transform.position = regla.posiblesPosiciones[index].position;
                regla.objeto.transform.rotation = regla.posiblesPosiciones[index].rotation;
                regla.objeto.SetActive(true);
            }
        }
    }
}