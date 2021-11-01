using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeMng : MonoBehaviour
{
    private static FadeMng instance;

    public static FadeMng Instance
    {
        get
        {
            if (instance == null)
                return null;

            return instance;
        }
    }

    [SerializeField]
    [Range(0.01f, 10f)]
    private float fadeTime;

    public float FadeTime
    {
        get { return fadeTime; }
        set { fadeTime = value; }
    }

    [SerializeField]
    private Image fadePanel;

    private bool isFade = false;

    public bool IsFade
    {
        get { return isFade; }
        set { isFade = value; }
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

    public void Fade(float start, float end)
    {
        if (IsFade == true)
            return;

        StartCoroutine(IEFade(start, end));
    }

    IEnumerator IEFade(float start, float end)
    {
        IsFade = true;
        fadePanel.raycastTarget = true;

        float currentTime = 0f;
        float percent = 0f;

        while(percent < 1f)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / FadeTime;

            Color panelColor = fadePanel.color;
            panelColor.a = Mathf.Lerp(start, end, percent);
            fadePanel.color = panelColor;

            yield return null;
        }

        fadePanel.raycastTarget = false;
        IsFade = false;
    }
}
