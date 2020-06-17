using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_InGame : MonoBehaviour
{
    [SerializeField] private GameObject _helpPanel;
    [SerializeField] private GameStarter gameStarter;

    private bool paused = false;
    public void Button_Click_Pause()
    {
        Time.timeScale = paused ? 1.0f : 0.0f;
        paused = !paused;
    }
    public void Button_Click_Help()
    {
        _helpPanel.SetActive(_helpPanel.activeInHierarchy? false:true);
    }
    public void Button_Click_Restart()
    {
        paused = false;
        Time.timeScale = 1.0f;
        gameStarter.Restart();
    }
    public void Button_Click_Quit()
    {
        paused = false;
        Time.timeScale = 1.0f;
        gameStarter.BackToMenu();
    }

}
