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

    public void MostrarOverlay()
    {
        presionarEUI.SetActive(false);
        infoOverlayUI.SetActive(true);
        camaraControl.camaraBloqueada = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CerrarOverlay()
    {
        infoOverlayUI.SetActive(false);

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

    // Liberar el cursor, si es necesario para interacción con UI
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
    }
}