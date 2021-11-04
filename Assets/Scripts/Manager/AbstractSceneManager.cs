using System;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class ASceneManager : MonoBehaviour {
    [SerializeField] private bool isPaused = false;

    public void MoveToMainMenuScene() {
        isPaused = false;
        Time.timeScale = 1;
        SceneManagerController.Load(SceneEnum.MainMenuScene);
    }

    public void MoveToGameScene() {
        isPaused = false;
        Time.timeScale = 1;
        SceneManagerController.Load(SceneEnum.FirstLevelFirstPlan, true);
    }

    public void MoveToOptionScene() {
        isPaused = true;
        Time.timeScale = 0;
        SceneManagerController.Load(SceneEnum.OptionScene);
    }

    public void MoveToLeaveScene() {
        isPaused = false;
        Time.timeScale = 1;
        Application.Quit();
    }

    public void MoveToGameOverScene() {
        isPaused = false;
        Time.timeScale = 1;
        SceneManagerController.Load(SceneEnum.GameOverScene);
    }

    public void MoveToGameWinScene() {
        isPaused = false;
        Time.timeScale = 1;
        SceneManagerController.Load(SceneEnum.GameWinScene);
    }

    public void MoveToPauseScene() {
        isPaused = true;
        Time.timeScale = 0;
        /**
         * Faire un prefab du menu des options
         * Lorsque pause active :
         * - ouvrir un canvas
         * - display le prefabs du menu options
         */
        SceneManagerController.Load(SceneEnum.PauseScene);
    }

    public void MoveToInventoryScene() {
        isPaused = true;
        Time.timeScale = 0;
        /**
         * Faire un prefab du menu des options
         * Lorsque pause active :
         * - ouvrir un canvas
         * - display le prefabs du menu options
         */
        SceneManagerController.Load(SceneEnum.InventoryScene);
    }

    public void MoveToLatestScene() {
        bool needLoading = GameManager.Instance.LatestScene == SceneEnum.GameScene;
        SceneManagerController.Load(GameManager.Instance.LatestScene, needLoading);
    }
}
