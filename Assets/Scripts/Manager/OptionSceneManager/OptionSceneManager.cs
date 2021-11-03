using UnityEngine;

public class OptionSceneManager : ASceneManager {
    private static OptionSceneManager _instance;

    #region Getter

    public static OptionSceneManager Instance {
        get {
            if (_instance == null)
                _instance = FindObjectOfType<OptionSceneManager>();
            if (_instance == null)
                Debug.LogError("OptionSceneManager not found");
            return _instance;
        }
    }

    #endregion Getter

    public void ShowUserControlPanel() {
        UserControlPanel.Instance.Show();
        VolumePanel.Instance.Hide(1);
        ScreenResolutionPanel.Instance.Hide(1);
    }

    public void ShowVolumePanelMenu() {
        UserControlPanel.Instance.Hide(-1);
        VolumePanel.Instance.Show();
        ScreenResolutionPanel.Instance.Hide(1);
    }

    public void ShowScreenResolutionPanel() {
        UserControlPanel.Instance.Hide(-2);
        VolumePanel.Instance.Hide(-1);
        ScreenResolutionPanel.Instance.Show(); 
    }

}
