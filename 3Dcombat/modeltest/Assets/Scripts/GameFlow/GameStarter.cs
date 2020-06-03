using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameStarter : MonoBehaviour
{
    public List<GameObject> _enemies;
    public Canvas _canvas;

    [SerializeField] private GameStarter_HitOnSkull _gameStarter_HitOnSkull;
 
    private void Awake()
    {
        foreach (var e in _enemies)
        {
            e.SetActive(false);
        }
    }

    public void GameStart()
    {
        foreach (var e in _enemies)
        {
            e.SetActive(true);
        }
        //_canvas.enabled = false;
    }

    public void Restart()
    {
        _gameStarter_HitOnSkull.enabled = true;
        SceneManager.LoadSceneAsync(1);
    }
    public void BackToMenu()
    {
 
        SceneManager.LoadSceneAsync(0);
    }
}
