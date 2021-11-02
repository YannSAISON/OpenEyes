using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneManagerController {
    private class LoadingBehaviour : MonoBehaviour {
    }

    private static Action _onLoaderCallback;
    private static AsyncOperation _asyncOperation;

    public static void Load(SceneEnum scene, bool loadingNeeded = false) {
        if (loadingNeeded) {
            _onLoaderCallback = () => {
                GameObject loadingGameObject = new GameObject("LoadingGameObject");

                loadingGameObject.AddComponent<LoadingBehaviour>().StartCoroutine(LoadAsyncScene(scene));
            };
        }
        SceneManager.LoadScene(SceneEnum.LoadingScene.ToString());
    }

    public static void LoadCallback() {
        if (_onLoaderCallback != null) {
            _onLoaderCallback();
            _onLoaderCallback = null;
        }
    }

    public static float GetLoadingProgress() {
        return _asyncOperation?.progress ?? 1.0f;
    }

    private static IEnumerator LoadAsyncScene(SceneEnum scene) {
        yield return null;

        _asyncOperation = SceneManager.LoadSceneAsync(scene.ToString());

        while (!_asyncOperation.isDone) {
            yield return new WaitForSeconds(2);
            yield return null;
        }
    }
}
