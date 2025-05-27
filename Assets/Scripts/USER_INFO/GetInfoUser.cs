using UnityEngine;
using TMPro;

public class GetInfoUser : MonoBehaviour
{
    public TMP_Text textoBienvenida;

    void Start()
    {
        string nombre = UserManager.Instance.ObtenerNombre();
        textoBienvenida.text = $"¡Bienvenido, {nombre}!";
    }
}
