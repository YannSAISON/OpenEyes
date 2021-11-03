using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UserControlPanel : MonoBehaviour {
    [SerializeField] private RectTransform rectTransform;

    private const float Speed = 0.3f;

    #region Getter

    private static UserControlPanel _instance;

    public static UserControlPanel Instance {
        get {
            if (_instance == null)
                _instance = FindObjectOfType<UserControlPanel>();
            if (_instance == null)
                Debug.LogError("UserControlPanel not found");
            return _instance;
        }
    }

    #endregion Getter

    private void Awake() {
        name = "UserControlPanel";
        rectTransform = GetComponent<RectTransform>();
        rectTransform.DOAnchorPosX(rectTransform.rect.width * -2, 0f);
    }

    public void Show(float delay = 0f) {
        rectTransform.DOAnchorPosX(0, 0.3f).SetDelay(delay);
    }

    public void Hide(int numberOfRectTransform, float delay = 0f) {
        rectTransform.DOAnchorPosX(rectTransform.rect.width * numberOfRectTransform, 0.3f).SetDelay(delay);
    }
}
