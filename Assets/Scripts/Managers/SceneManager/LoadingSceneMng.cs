using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneMng : MonoBehaviour
{
    [SerializeField]
    private Image[] images;
    [SerializeField]
    private Image progressBar;

    private string nextScene;

    void Start()
    {
        FadeMng.Instance.Fade(0, 0);

        for (int i = 0; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(false);
        }

        rndImage();
        nextScene = GameManager.Instance.NextScene;

        Loading();
    }

    void rndImage()
    {
        int rnd = Random.Range(0, images.Length);

        images[rnd].gameObject.SetActive(true);
    }

    void Loading()
    {
        StartCoroutine(IELoading());
    }

    IEnumerator IELoading()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(nextScene);
        operation.allowSceneActivation = false;

        float timer = 0f;
        float loadingTime = 5f;
        float percent = 0f;

        while (!operation.isDone)
        {
            yield return null;

            timer += Time.deltaTime;
            percent = timer / loadingTime;

            progressBar.fillAmount = Mathf.Lerp(0, 1, percent);

            if(progressBar.fillAmount == 1f)
            {
                operation.allowSceneActivation = true;
                yield break; 
            }
        }
    }
}
