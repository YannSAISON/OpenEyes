using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }
    private SceneEnum ActualScene { get; set; }
    public SceneEnum LatestScene { get; set; }

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        ActualScene = SceneEnum.OpeningScene;
        LatestScene = SceneEnum.OpeningScene;
        if (SceneManager.GetActiveScene().name != SceneEnum.OpeningScene.ToString())
            SceneManager.LoadScene(ActualScene.ToString());
    }

    public void ChangeScene(SceneEnum newScene) {
        LatestScene = ActualScene;
        ActualScene = newScene;
    }
}
