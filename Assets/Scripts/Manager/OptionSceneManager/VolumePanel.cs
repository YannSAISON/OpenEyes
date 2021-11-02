using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class VolumePanel : MonoBehaviour {
    private RectTransform m_RectTransform;

    #region Getter

    static VolumePanel _instance;

    public static VolumePanel Instance {
        get {
            if (_instance == null)
                _instance = FindObjectOfType<VolumePanel>();
            if (_instance == null)
                Debug.LogError("HomeUIManager not found");
            return _instance;
        }
    }

    #endregion Getter

    private void Awake() {
        m_RectTransform = GetComponent<RectTransform>();
        m_RectTransform.DOAnchorPosX(0, 0f);
    }

    public void Show(float delay = 0f) {
        m_RectTransform.DOAnchorPosX(0, 0.3f).SetDelay(delay);
    }

    public void Hide(float delay = 0f) {
        m_RectTransform.DOAnchorPosX(m_RectTransform.rect.width * -1, 0.3f).SetDelay(delay);
    }
}
