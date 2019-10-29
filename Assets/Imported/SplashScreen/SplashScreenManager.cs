using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashScreenManager : MonoBehaviour
{
    public Image logo;
    public string level;

    // Start is called before the first frame update

    IEnumerator Start()
    {
        logo.canvasRenderer.SetAlpha(0);

        FadeIn();
        yield return new WaitForSeconds(1.5f);
        FadeOut();
        yield return new WaitForSeconds(1);
        SceneTransitioner.instance.LoadScene(level, 0);
    }

    void FadeIn()
    {
        logo.CrossFadeAlpha(1, 1, true);
    }

    void FadeOut()
    {
        logo.CrossFadeAlpha(0, 1, true);
    }

}
