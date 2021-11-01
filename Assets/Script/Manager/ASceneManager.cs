using System;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class ASceneManager : MonoBehaviour {
    [SerializeField] private bool isPaused = false;

    public void MoveToMainMenuScene() {
        isPaused = false;
        Time.timeScale = 1;
        GameManager.Instance.SceneManager.Load(SceneEnum.MainMenuScene);
    }

    public void MoveToGameScene() {
        isPaused = false;
        Time.timeScale = 1;
        GameManager.Instance.SceneManager.Load(SceneEnum.GameScene);
    }
    
    public void MoveToOptionScene() {
        isPaused = true;
        Time.timeScale = 0;
        GameManager.Instance.SceneManager.Load(SceneEnum.OptionScene);
    }

    public void MoveToLeaveScene() {
        isPaused = false;
        Time.timeScale = 1;
        Application.Quit();
    }

    public void MoveToGameOverScene() {
        isPaused = false;
        Time.timeScale = 1;
        GameManager.Instance.SceneManager.Load(SceneEnum.GameOverScene);
    }

    public void MoveToGameWinScene() {
        isPaused = false;
        Time.timeScale = 1;
        GameManager.Instance.SceneManager.Load(SceneEnum.GameWinScene);
    }

    public void MoveToPauseScene() {
        isPaused = true;
        Time.timeScale = 0;
        GameManager.Instance.SceneManager.Load(SceneEnum.PauseScene);
    }

    public void MoveToInventoryScene() {
        isPaused = true;
        Time.timeScale = 0;
        GameManager.Instance.SceneManager.Load(SceneEnum.InventoryScene);
    }

    public void MoveToLatestScene() {
        GameManager.Instance.SceneManager.Load(GameManager.Instance.LatestScene);
    }
}
