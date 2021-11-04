using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionSceneManager : ASceneManager {
    private static OptionSceneManager _instance;

    #region Getter

    public static OptionSceneManager Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<OptionSceneManager>();
            }

            if (_instance == null)
                Debug.LogError("OptionSceneManager not found");
            return _instance;
        }
    }

    #endregion Getter

    private void Awake() {
        UserControlPanel.Instance.gameObject.SetActive(true);
        VolumePanel.Instance.gameObject.SetActive(false);
        ScreenResolutionPanel.Instance.gameObject.SetActive(false);
    }

    public void ShowUserControlPanel() {
        Debug.Log("ShowUserControlPanel");
        UserControlPanel.Instance.gameObject.SetActive(true);
        VolumePanel.Instance.gameObject.SetActive(false);
        ScreenResolutionPanel.Instance.gameObject.SetActive(false);
    }

    public void ShowVolumePanelMenu() {
        Debug.Log("ShowVolumePanelMenu");
        UserControlPanel.Instance.gameObject.SetActive(false);
        VolumePanel.Instance.gameObject.SetActive(true);
        ScreenResolutionPanel.Instance.gameObject.SetActive(false);
    }

    public void ShowScreenResolutionPanel() {
        UserControlPanel.Instance.gameObject.SetActive(false);
        VolumePanel.Instance.gameObject.SetActive(false);
        ScreenResolutionPanel.Instance.gameObject.SetActive(true);
    }
}
