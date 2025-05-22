using UnityEngine;
using UnityEngine.UI;

public class ObjectLookOverlay : MonoBehaviour
{
    public Camera mainCamera;
    public Transform targetObject;
    public float maxViewAngle = 20f;

    public GameObject presionarEUI;       // Canvas World Space con "Presiona E"
    public GameObject infoOverlayUI;      // Canvas Overlay con la información
    public ControlCamara camaraControl;

    public GameObject siguienteGuia;

    public GameObject canvasFinal;

    public Transform jugador; // arrastra aquí el GameObject del jugador
    public Transform nuevaPosicion; // define un GameObject vacío en la nueva posición deseada

    private bool puedeInteractuar = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        presionarEUI.SetActive(false);
        infoOverlayUI.SetActive(false);
    }

    void Update()
    {
        // Si ya está en el overlay, no seguimos evaluando
        if (infoOverlayUI.activeSelf) return;

        // Calcula el ángulo entre la vista de la cámara y el objeto
        Vector3 directionToTarget = targetObject.position - mainCamera.transform.position;
        float angle = Vector3.Angle(mainCamera.transform.forward, directionToTarget);

        if (angle < maxViewAngle)
        {
            Ray ray = new Ray(mainCamera.transform.position, directionToTarget);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == targetObject)
                {
                    presionarEUI.SetActive(true);
                    puedeInteractuar = true;

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        MostrarOverlay();
                    }

                    return;
                }
            }
        }

        // Si no está mirando, desactiva la UI
        presionarEUI.SetActive(false);
        puedeInteractuar = false;
    }

    
    public void MoverJugadorANuevaPosicion()
    {
        jugador.position = nuevaPosicion.position;
        jugador.rotation = nuevaPosicion.rotation;
        canvasFinal.SetActive(false); // Opcional: ocultar canvas final
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void MostrarOverlay()
    {
        presionarEUI.SetActive(false);
        infoOverlayUI.SetActive(true);

        // Pausar el juego
        Time.timeScale = 0f;

        // Bloquear movimiento de cámara
        camaraControl.camaraBloqueada = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CerrarOverlay()
    {
        infoOverlayUI.SetActive(false);

        // Reanudar el juego
        Time.timeScale = 1f;

        // Restaurar control de cámara
        if (camaraControl != null)
            camaraControl.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Apagar este objeto guía
        targetObject.gameObject.SetActive(false);

        // Activar el siguiente (si está definido)
        if (siguienteGuia != null)
            siguienteGuia.SetActive(true);
    }

    public void MostrarCanvasFinal()
    {
        infoOverlayUI.SetActive(false);
        canvasFinal.SetActive(true);

        // Reanudar el juego (por seguridad)
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
