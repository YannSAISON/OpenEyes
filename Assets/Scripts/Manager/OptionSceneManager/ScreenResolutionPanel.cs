using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ScreenResolutionPanel : MonoBehaviour {
    [SerializeField] private RectTransform rectTransform;
    private static List<int> Widths { get; set; }
    private static List<int> Heights { get; set; }

    private static List<string> Resolution { get; set; }
    private static List<string> Quality { get; set; }
    private const float Speed = 0.3f;

    public Dropdown dropdownSelectResolution;
    public Dropdown dropdownSelectQuality;
    public Toggle toggleSelectFullScreen;


    #region Getter

    private static ScreenResolutionPanel _instance;

    public static ScreenResolutionPanel Instance {
        get {
            if (_instance == null)
                _instance = FindObjectOfType<ScreenResolutionPanel>();
            if (_instance == null)
                Debug.LogError("UserControlPanel not found");
            return _instance;
        }
    }

    #endregion Getter

    private void Awake() {
        name = "ScreenResolutionPanel";
        rectTransform = GetComponent<RectTransform>();
        rectTransform.DOAnchorPosX(0, 0f);
        SetupProperties();
        SetupDropDownResolution();
        SetupDropDownQuality();
        SetupToggleFullScreen();
    }

    public void Show(float delay = 0f) {
        rectTransform.DOAnchorPosX(0, 0.3f).SetDelay(delay);
    }

    public void Hide(int numberOfRectTransform, float delay = 0f) {
        rectTransform.DOAnchorPosX(rectTransform.rect.width * numberOfRectTransform, 0.3f).SetDelay(delay);
    }

    #region Setup

    private void SetupProperties() {
        Widths = new List<int>() {3840, 2560, 1920, 800};
        Heights = new List<int>() {2160, 1440, 1080, 600};
        Resolution = new List<string>() {"3840 * 2160", "2560 * 1440", "1920 * 1080", "800 * 600"};
        Quality = new List<string>();

        string[] arrayQualityName = QualitySettings.names;
        foreach (var qualityName in arrayQualityName) {
            Quality.Add(qualityName);
        }
    }

    private void SetupDropDownResolution() {
        dropdownSelectResolution.ClearOptions();
        dropdownSelectResolution.AddOptions(Resolution);
        int actualScreenWidth = PlayerPrefs.GetInt(ConstantManager.ScreenWidth);
        int actualScreenHeight = PlayerPrefs.GetInt(ConstantManager.ScreenHeight);
        int indexWidth = Widths.FindIndex(width => width == actualScreenWidth);
        int indexHeight = Heights.FindIndex(height => height == actualScreenHeight);

        if (indexHeight != indexWidth) {
            throw new NotImplementedException();
        }

        dropdownSelectResolution.value = indexWidth;
        dropdownSelectResolution.onValueChanged.AddListener(delegate {
            DropdownSelectResolutionOnChange(dropdownSelectResolution);
        });
    }

    private void SetupDropDownQuality() {
        dropdownSelectQuality.ClearOptions();
        dropdownSelectQuality.AddOptions(Quality);
        dropdownSelectQuality.onValueChanged.AddListener(delegate {
            DropdownSelectQualityOnChange(dropdownSelectQuality);
        });
    }

    private void SetupToggleFullScreen() {
        bool fullScreen = PlayerPrefs.GetInt(ConstantManager.FullScreen) == 1;
        toggleSelectFullScreen.isOn = fullScreen;
        toggleSelectFullScreen.onValueChanged.AddListener(delegate {
            ToggleSelectFullScreenOnChange(toggleSelectFullScreen);
        });
    }

    #endregion Setup

    #region OnChange

    private void DropdownSelectResolutionOnChange(Dropdown change) {
        GameManager.Instance.UpdateScreenSize(Widths[change.value], Heights[change.value]);
    }

    private void DropdownSelectQualityOnChange(Dropdown change) {
        GameManager.Instance.UpdateScreenQuality(change.value);
    }

    private void ToggleSelectFullScreenOnChange(Toggle change) {
        GameManager.Instance.UpdateScreenFullScreen(change.isOn);
    }

    #endregion
}
