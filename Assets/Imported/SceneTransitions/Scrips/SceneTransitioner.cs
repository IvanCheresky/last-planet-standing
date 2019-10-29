using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitioner : MonoBehaviour
{
    public static SceneTransitioner instance;
    public List<Animator> animators;
    private bool blocked = false;
    public GameObject loadingAnim;

    void Awake()
    {

        if(instance == null)
        {
            instance = this;
        } else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneName)
    {
        int animatorIndex = Random.Range(0, animators.Count);
        LoadScene(sceneName, animatorIndex);
    }

    public void LoadScene(int sceneIndex)
    {
        int animatorIndex = Random.Range(0, animators.Count);
        LoadScene(sceneIndex, animatorIndex);
    }

    public void LoadScene(string sceneName, int animatorIndex)
    {
        if (!blocked)
        {
            blocked = true;
            animators[0].GetComponent<Image>().raycastTarget = true;
            animators[animatorIndex].Play("Fade In");
            StartCoroutine(Wait1Sec(sceneName, animatorIndex));
        }
    }

    public void LoadScene(int sceneIndex, int animatorIndex)
    {
        if (!blocked)
        {
            blocked = true;
            animators[0].GetComponent<Image>().raycastTarget = true;
            animators[animatorIndex].Play("Fade In");
            StartCoroutine(Wait1Sec(sceneIndex, animatorIndex));
        }
    }

    IEnumerator Wait1Sec(string sceneName, int animatorIndex)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);

        loadingAnim.SetActive(true);

        while (SceneManager.GetActiveScene().name != sceneName)
        {
            yield return new WaitForSeconds(0.1f);
        }

        loadingAnim.SetActive(false);

        animators[animatorIndex].Play("Fade Out");
        yield return new WaitForSeconds(0.8f);
        animators[0].GetComponent<Image>().raycastTarget = false;
        blocked = false;
    }

    IEnumerator Wait1Sec(int sceneIndex, int animatorIndex)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneIndex);

        loadingAnim.SetActive(true);

        while (SceneManager.GetActiveScene().buildIndex != sceneIndex)
        {
            yield return new WaitForSeconds(0.1f);
        }

        loadingAnim.SetActive(false);

        animators[animatorIndex].Play("Fade Out");
        yield return new WaitForSeconds(0.8f);
        animators[0].GetComponent<Image>().raycastTarget = false;
        blocked = false;
    }

}
