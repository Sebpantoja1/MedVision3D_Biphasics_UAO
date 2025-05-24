using UnityEngine;

public class ControlCanvasButton : MonoBehaviour
{
    public GameObject canvasActual;
    public GameObject canvasIntroNivel2;

    public void IrANivel2()
    {
        canvasActual.SetActive(false);
        canvasIntroNivel2.SetActive(true);

        // Desbloquear y mostrar el cursor para permitir interacción con el nuevo canvas
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // (Opcional) Si estás pausando el tiempo como en otros overlays, puedes agregar:
        //Time.timeScale = 0f;
    }
    public void CerrarCanvasActual()
    {
        canvasIntroNivel2.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}