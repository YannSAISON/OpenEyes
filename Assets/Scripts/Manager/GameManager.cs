using System;
using DG.Tweening;
using UnityEngine;

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
        SetupWindowsData();
        ActualScene = SceneEnum.MainMenuScene;
        LatestScene = SceneEnum.MainMenuScene;
    }

    private void Update() {
        MoveToLatestScene();
    }

    public void ChangeScene(SceneEnum newScene) {
        LatestScene = ActualScene;
        ActualScene = newScene;
    }

    private void SetupWindowsData() {
        int width = PlayerPrefs.GetInt(ConstantManager.ScreenWidth);
        int height = PlayerPrefs.GetInt(ConstantManager.ScreenHeight);
        bool fullScreen = PlayerPrefs.GetInt(ConstantManager.FullScreen) == 1;
        int quality = PlayerPrefs.GetInt(ConstantManager.ScreenQuality);

        Screen.SetResolution(width, height, fullScreen);
        QualitySettings.SetQualityLevel(quality, true);
    }

    #region ScreenResolutionPanel

    public void UpdateScreenSize(int width, int height) {
        bool fullScreen = PlayerPrefs.GetInt(ConstantManager.FullScreen) == 1;
        Screen.SetResolution(width, height, fullScreen);
        PlayerPrefs.SetInt(ConstantManager.ScreenWidth, width);
        PlayerPrefs.SetInt(ConstantManager.ScreenHeight, height);
    }

    public void UpdateScreenQuality(int quality) {
        QualitySettings.SetQualityLevel(quality, true);
        PlayerPrefs.SetInt(ConstantManager.ScreenQuality, quality);
    }

    public void UpdateScreenFullScreen(bool fullScreen) {
        int width = PlayerPrefs.GetInt(ConstantManager.ScreenWidth);
        int height = PlayerPrefs.GetInt(ConstantManager.ScreenHeight);
        Screen.SetResolution(width, height, fullScreen);
        PlayerPrefs.SetInt(ConstantManager.ScreenQuality, fullScreen ? 1 : 0);
    }

    #endregion ScreenResolutionPanel

    #region GlobalKeyBoardControl

    private void MoveToLatestScene() {
        switch (ActualScene) {
            case SceneEnum.OpeningScene:
                break;
            case SceneEnum.LoadingScene:
                break;
            case SceneEnum.MainMenuScene:
                break;
            case SceneEnum.GameScene:
                break;
            case SceneEnum.OptionScene:
                if (Input.GetKeyDown(KeyCode.Escape)) SceneManagerController.Load(LatestScene);
                break;
            case SceneEnum.GameOverScene:
                break;
            case SceneEnum.GameWinScene:
                break;
            case SceneEnum.PauseScene:
                break;
            case SceneEnum.EquipmentScene:
                if (Input.GetKeyDown(KeyCode.Escape)) SceneManagerController.Load(LatestScene);
                break;
            case SceneEnum.AchievementScene:
                if (Input.GetKeyDown(KeyCode.Escape)) SceneManagerController.Load(LatestScene);
                break;
        }
    }

    #endregion
}
