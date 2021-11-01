using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMng : MonoBehaviour
{
    private static SceneMng instance;

    public static SceneMng Instance
    {
        get
        {
            if (instance == null)
                return null;

            return instance;
        }
    }

    void Awake()
    {
        Singleton();
    }

    void Singleton()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }

    public void changeSceneAsync(string nextScene)
    {
        StartCoroutine(IEchangeSceneAsync(nextScene));
    }

    public void changeScene(string nextScene)
    {
        StartCoroutine(IEchangeScene(nextScene));
    }

    IEnumerator IEchangeSceneAsync(string nextScene)
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadSceneAsync(nextScene);
    }

    IEnumerator IEchangeScene(string nextScene)
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(nextScene);
    }
}
