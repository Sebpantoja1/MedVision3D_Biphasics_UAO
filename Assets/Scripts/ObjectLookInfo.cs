using UnityEngine;
using UnityEngine.UI;

public class ObjectLookInfo : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject infoCanvas; // Canvas World Space
    public Transform targetObject; // Objeto de referencia
    public float maxViewAngle = 20f; // Ángulo tolerancia

    void Start()
    {
        infoCanvas.SetActive(false);
    }

    void Update()
    {
        Vector3 directionToTarget = targetObject.position - mainCamera.transform.position;
        float angle = Vector3.Angle(mainCamera.transform.forward, directionToTarget);

        if (angle < maxViewAngle)
        {
            // Verificar línea de visión con raycast
            Ray ray = new Ray(mainCamera.transform.position, directionToTarget);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == targetObject)
                {
                    infoCanvas.SetActive(true);
                    infoCanvas.transform.LookAt(mainCamera.transform);
                    infoCanvas.transform.Rotate(0, 180, 0);
                }
                else
                {
                    infoCanvas.SetActive(false);
                }
            }
        }
        else
        {
            infoCanvas.SetActive(false);
        }
    }
}
