using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class UserControlPanel : MonoBehaviour {
    [SerializeField] private RectTransform rectTransform;

    #region Getter

    static UserControlPanel _instance;

    public static UserControlPanel Instance {
        get {
            if (_instance == null)
                _instance = FindObjectOfType<UserControlPanel>();
            if (_instance == null)
                Debug.LogError("HomeUIManager not found");
            return _instance;
        }
    }

    #endregion Getter

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.DOAnchorPosX(0, 0f);
    }

    public void Show(float delay = 0f) {
        rectTransform.DOAnchorPosX(0, 0.3f).SetDelay(delay);
    }

    public void Hide(int numberOfRectTransform, float delay = 0f) {
        rectTransform.DOAnchorPosX(rectTransform.rect.width * numberOfRectTransform, 0.3f).SetDelay(delay);
    }
}
