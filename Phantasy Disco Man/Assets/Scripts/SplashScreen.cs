using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

    public Image cuttlefishLogo;
    public Image gameLogo;
    public Camera[] cam;


    public string loadLevel = "Skills";

    IEnumerator Start()
    {
        cuttlefishLogo.canvasRenderer.SetAlpha(0.0f);
        gameLogo.canvasRenderer.SetAlpha(0.0f);
        FadeInC();
        yield return new WaitForSeconds(4f);
        FadeOutC();
        yield return new WaitForSeconds(2.5f);
        FadeInL();
        yield return new WaitForSeconds(4f);
        FadeOutL();
        //ChangeBackground();
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(loadLevel);
    }

    void FadeInC()
    {
        cuttlefishLogo.CrossFadeAlpha(1.0f, 1.5f, false);
    }

    void FadeOutC()
    {
        cuttlefishLogo.CrossFadeAlpha(0, 1.5f, false);
    }

    void FadeInL()
    {
        gameLogo.CrossFadeAlpha(1.0f, 1.5f, false);
    }

    void FadeOutL()
    {
        gameLogo.CrossFadeAlpha(0, 1.5f, false);
    }

    /*void ChangeBackground()
    {
        float t = Mathf.PingPong(Time.time, 3.0F) / 3.0F;
        Color myColor = new Color();
        ColorUtility.TryParseHtmlString("7C400000", out myColor);
        //cam.backgroundColor = Color.Lerp(Color.white, myColor, t);
    }*/

}
