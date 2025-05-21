using UnityEngine;

public class UIManagerMain : MonoBehaviour
{
    public GameObject canvasFinalOverlay;

    void Start()
    {
        if (canvasFinalOverlay != null)
            canvasFinalOverlay.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
