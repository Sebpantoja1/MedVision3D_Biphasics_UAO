using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginUI : MonoBehaviour
{
    public TMP_InputField inputNombre;
    public string nombreEscena;

    public void GuardarNombreYContinuar()
    {
        string nombre = inputNombre.text;
        if (!string.IsNullOrWhiteSpace(nombre))
        {
            UserManager.Instance.GuardarNombre(nombre);
            // Cargar siguiente escena o continuar flujo
            SceneManager.LoadScene(nombreEscena);
        }
        else
        {
            Debug.LogWarning("El nombre no puede estar vacío");
        }
    }
}