using UnityEngine;

public class UserManager : MonoBehaviour
{
    public static UserManager Instance;

    private string nombreUsuario;

    private void Awake()
    {
        // Singleton simple para acceso global
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Para mantener datos entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GuardarNombre(string nombre)
    {
        nombreUsuario = nombre.Trim();
        Debug.Log("Nombre usuario guardado: " + nombreUsuario);
    }

    public string ObtenerNombre()
    {
        return nombreUsuario;
    }
}