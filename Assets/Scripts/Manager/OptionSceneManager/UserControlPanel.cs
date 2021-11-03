using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UserControlPanel : MonoBehaviour {
    [SerializeField] private RectTransform rectTransform;

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
        gameObject.transform.position = new Vector3(0, 0, 0);
    }
}
