using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    private void Start()
    {
    //MusicManager.instance.SetVolume(1f);
    }
    public void OnPlayBtn()
    {
        SceneManager.LoadScene("CoffeeShop");
    }
    public void OnQuitBtn()
    {
       Application.Quit();
    }
}
