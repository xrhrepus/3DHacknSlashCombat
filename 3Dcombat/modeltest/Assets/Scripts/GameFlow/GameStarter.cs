using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameStarter : MonoBehaviour
{
    public List<GameObject> _enemies;
    public Canvas _canvas;
    [SerializeField]
    private float musicFadeTime = 5.0f;
    [SerializeField] private GameStarter_HitOnSkull _gameStarter_HitOnSkull;
    [SerializeField] private AudioSource _bgm;
    [SerializeField] private SFXGroup _gameStartHint;

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
        //{
        //    string voice = "haunt" + (int)Random.Range(1, 3);
        //    _gameStartHint.PlaySFX(voice);
        //}
        _gameStartHint.PlaySFX("haunt1");
        _gameStartHint.PlaySFX("haunt2");
        _gameStartHint.PlaySFX("haunt3");


        _bgm.Play();
        StartCoroutine(FadeIn(_bgm, musicFadeTime));

        //_canvas.enabled = false;
    }
    IEnumerator FadeOutBGM(float sec)
    {
        float d = 1.0f / sec;
        for (int i = 0; i < sec; i++)
        {
            _bgm.volume -= d;
            yield return new WaitForSeconds(sec);
        }
        _bgm.volume = 0.0f;

    }
    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }

    public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
    {
        float startVolume = 0.3f;

        audioSource.volume = 0;
        audioSource.Play();

        while (audioSource.volume < 1.0f)
        {
            audioSource.volume += startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.volume = 1f;
    }
    public void Restart()
    {
        _gameStarter_HitOnSkull.enabled = true;
        //StartCoroutine(FadeOutBGM(3.0f));
        StartCoroutine(FadeOut(_bgm, musicFadeTime));

        SceneManager.LoadSceneAsync(1);
    }
    public void BackToMenu()
    {
        StartCoroutine(FadeOut(_bgm, musicFadeTime));
        SceneManager.LoadSceneAsync(0);
    }
}
