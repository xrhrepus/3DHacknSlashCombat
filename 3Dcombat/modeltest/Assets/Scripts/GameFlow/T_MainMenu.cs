using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class T_MainMenu : MonoBehaviour
{
    public void StartClicked()
    {
        SceneManager.LoadSceneAsync(1);

    }
    public void QuitClicked()
    {
        Application.Quit();
    }

}
