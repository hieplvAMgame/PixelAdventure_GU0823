using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : Singleton<LoadingScreen>
{
    [SerializeField] GameObject canvasObj = default;
    [SerializeField] Image progressBar = default;

    bool isLoaded = false;
    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
    public void ActiveScene()
    {
        canvasObj.SetActive(false);
    }
    public void GoToScene(string sceneName, Action callback)
    {
        canvasObj.SetActive(true);
        StartCoroutine(FadeOutScene(sceneName, callback));

    }
    IEnumerator FadeInScene(string sceneName, Action callback)
    {
        yield return new WaitForEndOfFrame();
        callback?.Invoke();
        if (!isLoaded)
        {
            // Do sthing after this class loaded
            isLoaded = true;
        }
    }
    IEnumerator FadeOutScene(string sceneName, Action callback)
    {
        canvasObj?.SetActive(true);
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;
        while (!async.isDone)
        {
            progressBar.fillAmount = async.progress / 2;
            yield return null;
            if (async.progress >= 0.9f)
            {
                async.allowSceneActivation = true;
            }
        }
        // make smooth progress bar after loading done and active scene
        float time = 1;
        while (time > 0)
        {
            time -= Time.deltaTime;
            progressBar.fillAmount += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        progressBar.fillAmount = 1;
        yield return new WaitForSeconds(.2f);

        StartCoroutine(FadeInScene(sceneName, callback));
    }
}
