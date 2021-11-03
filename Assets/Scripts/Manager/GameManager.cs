using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }
    private SceneEnum ActualScene { get; set; }
    public SceneEnum LatestScene { get; set; }

    private const string ScreenWidth = "sc_width";
    private const string ScreenHeight = "sc_height";

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        SetupWindowsData();
        ActualScene = SceneEnum.OpeningScene;
        LatestScene = SceneEnum.OpeningScene;
        if (SceneManager.GetActiveScene().name != SceneEnum.OpeningScene.ToString())
            SceneManager.LoadScene(ActualScene.ToString());
    }

    public void ChangeScene(SceneEnum newScene) {
        LatestScene = ActualScene;
        ActualScene = newScene;
    }

    private void SetupWindowsData() {
        PlayerPrefs.SetInt(ScreenWidth, 1920);
        PlayerPrefs.SetInt(ScreenHeight, 1080);
        int width = PlayerPrefs.GetInt(ScreenWidth);
        int height = PlayerPrefs.GetInt(ScreenHeight);
        bool fullScreen = Screen.fullScreen;
        Screen.SetResolution(width, height, fullScreen);
        
        Debug.Log("ScreenWidth : " + width.ToString());
        Debug.Log("ScreenHeight : " + height.ToString());
        Debug.Log("Screen.fullScreen : " + fullScreen.ToString());
        
    }
}
