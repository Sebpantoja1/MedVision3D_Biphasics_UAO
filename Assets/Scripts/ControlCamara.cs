using UnityEngine;

public class ControlCamara : MonoBehaviour
{
    public bool camaraBloqueada = false;
    public float sensibilidad = 2f;
    public Transform jugador;

    void Update()
    {
        if (camaraBloqueada) return;

        float mouseX = Input.GetAxis("Mouse X") * sensibilidad;
        jugador.Rotate(Vector3.up * mouseX);
    }
}

