using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_InGame : MonoBehaviour
{
    [SerializeField] private GameObject _helpPanel;
    [SerializeField] private GameStarter gameStarter;

    public void Button_Click_Help()
    {
        _helpPanel.SetActive(_helpPanel.activeInHierarchy? false:true);
    }
    public void Button_Click_Restart()
    {
        gameStarter.Restart();
    }
    public void Button_Click_Quit()
    {
        gameStarter.BackToMenu();
    }

}
