using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Navigation : MonoBehaviour
{
    public void bukaGame1()
    {
        SceneManager.LoadScene("game 1");
    }

        public void bukaGame2()
    {
        SceneManager.LoadScene("game 2");
    }

    public string urlToOpen = "https://www.instagram.com/ar/809761637287341/";

    
    public void OpenURL()
    {
        Application.OpenURL(urlToOpen);
    }
}
