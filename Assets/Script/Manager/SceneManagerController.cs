using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public  class SceneManagerController : MonoBehaviour {
    private class LoadingBehaviour : MonoBehaviour {
    }

    private static Action _onLoaderCallback;
    private static AsyncOperation _asyncOperation;

    public void Load(SceneEnum scene) {
        _onLoaderCallback = () => {
            GameObject loadingGameObject = new GameObject("LoadingGameObject");

            loadingGameObject.AddComponent<LoadingBehaviour>().StartCoroutine(LoadAsyncScene(scene));
        };
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneEnum.LoadingScene.ToString());
    }

    public static void LoadCallback() {
        if (_onLoaderCallback == null) return;
        _onLoaderCallback();
        _onLoaderCallback = null;
    }

    public float GetLoadingProgress() {
        return _asyncOperation?.progress ?? 1.0f;
    }

    private static IEnumerator LoadAsyncScene(SceneEnum scene) {
        yield return null;

        _asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(scene.ToString());

        while (!_asyncOperation.isDone) {
            yield return null;
        }
    }
}
