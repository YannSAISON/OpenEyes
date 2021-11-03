using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


[RequireComponent(typeof(RectTransform))]
public class ScreenResolutionPanel : MonoBehaviour {
    [SerializeField] private RectTransform rectTransform;
    public static List<int> widths { get; private set; }
    public static List<int> heights { get; private set; }
    
    #region Getter

    private static ScreenResolutionPanel _instance;

    public static ScreenResolutionPanel Instance {
        get {
            if (_instance == null)
                _instance = FindObjectOfType<ScreenResolutionPanel>();
            if (_instance == null)
                Debug.LogError("OptionSceneManager not found");
            return _instance;
        }
    }

    #endregion Getter

    private void Awake() {
        widths = new List<int> {3840, 2560, 1920};
        heights = new List<int> {2160, 1440, 1080};
    }

    void Start() {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.DOAnchorPosX(rectTransform.rect.width * 2, 0f);
    }

    public void Show(float delay = 0f) {
        rectTransform.DOAnchorPosX(0, 0.3f).SetDelay(delay);
    }

    public void Hide(int numberOfRectTransform, float delay = 0f) {
        rectTransform.DOAnchorPosX(rectTransform.rect.width * numberOfRectTransform, 0.3f).SetDelay(delay);
    }
}
