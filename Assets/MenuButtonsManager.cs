using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonsManager : MonoBehaviour
{
    public void OnPlayPressed()
    {
        SceneTransitioner.instance.LoadScene("MainGame");
    }

    [SerializeField] GameObject configMenu;

    public void OnConfigPressed()
    {
        gameObject.SetActive(false);
        configMenu.SetActive(true);
    }
}
