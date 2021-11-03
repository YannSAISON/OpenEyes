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


    public void ShowUserControlPanel() {
        Debug.Log("ShowUserControlPanel");
        UserControlPanel.Instance.Show();
        VolumePanel.Instance.Hide(1);
        ScreenResolutionPanel.Instance.Hide(2);
    }

    public void ShowVolumePanelMenu() {
        Debug.Log("ShowVolumePanelMenu");
        UserControlPanel.Instance.Hide(-1);
        VolumePanel.Instance.Show();
        ScreenResolutionPanel.Instance.Hide(1);
    }

    public void ShowScreenResolutionPanel() {
        Debug.Log("ShowScreenResolutionPanel");
        UserControlPanel.Instance.Hide(2);
        VolumePanel.Instance.Hide(-1);
        ScreenResolutionPanel.Instance.Show();
    }
}
