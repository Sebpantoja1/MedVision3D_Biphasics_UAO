using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasNavigator : MonoBehaviour
{

    public CanvasGroup canvasLoad;
    public CanvasGroup canvasUser;
    public CanvasGroup canvasStartGuide;
    public CanvasGroup canvasFinishGuide;
    public CanvasGroup canvasSecondSession;
    public CanvasGroup canvasFinishSecond;

    float TransitionTime = 0.5f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MostrarCanvas(canvasLoad);
        OcultarCanvas(canvasUser, instant: true);
        OcultarCanvas(canvasStartGuide, instant: true);
        OcultarCanvas(canvasFinishGuide, instant: true);
        OcultarCanvas(canvasSecondSession, instant: true);
        OcultarCanvas(canvasFinishSecond, instant: true);


    }

    public void LoadScene(string NameScene)
    {
        SceneManager.LoadScene(NameScene);
    }

    public void InLoadtoUser()
    {
        TransicionCanvas(canvasLoad, canvasUser);

    }

    public void InInfoCanva()
    {
        TransicionCanvas(canvasUser, canvasStartGuide);
    }

    private void TransicionCanvas(CanvasGroup canvasOut, CanvasGroup canvasIn)
    {
        LeanTween.alphaCanvas(canvasOut, 0f, TransitionTime).setOnComplete(() =>
        {
            canvasOut.gameObject.SetActive(false);

        });

        canvasIn.gameObject.SetActive(true);
        canvasIn.alpha = 0f;
        LeanTween.alphaCanvas(canvasIn, 1f, TransitionTime); 

    }

    private void OcultarCanvas(CanvasGroup cg, bool instant = false)
    {
        cg.alpha = 0f;
        cg.gameObject.SetActive(!instant);
    }
    private void MostrarCanvas(CanvasGroup cg)
    {
        cg.alpha = 1f;
        cg.gameObject.SetActive(true);

    }
}
