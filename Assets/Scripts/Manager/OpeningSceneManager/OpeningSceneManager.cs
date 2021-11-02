using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Video;
using UnityEngine.UI;

public class OpeningSceneManager : MonoBehaviour {
    public VideoPlayer videoPlayer; // Drag & Drop the GameObject holding the VideoPlayer component
    public Text text;
    private const float SpeedToFadeText = 25f;

    private void Awake() {
        text.gameObject.SetActive(false);
    }

    private void Start() {
        videoPlayer.loopPointReached += LoadPanel;
    }

    private void LoadPanel(VideoPlayer vp) {
        videoPlayer.gameObject.SetActive(false);
    }

    private void Update() {
        double videoTime = videoPlayer.time;
        double videoLength = videoPlayer.length;

        if (text.color.a >= 0.99 && text.gameObject.activeSelf) {
            StartCoroutine(FadeTextToZeroAlpha(SpeedToFadeText, text));
        }

        if (videoTime / videoLength >= 0.95) {
            text.gameObject.SetActive(true);
            StartCoroutine(FadeTextToFullAlpha(SpeedToFadeText, text));
        }
    }


    private IEnumerator FadeTextToFullAlpha(float t, Text i) {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f) {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    private IEnumerator FadeTextToZeroAlpha(float t, Text i) {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f) {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            if (i.color.a <= 0.1f) {
                SceneManagerController.Load(SceneEnum.MainMenuScene);
            }

            yield return null;
        }

        yield return 1;
    }
}
