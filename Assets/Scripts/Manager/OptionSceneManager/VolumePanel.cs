using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class VolumePanel : MonoBehaviour {
    [SerializeField] protected RectTransform rectTransform;

    #region Getter

    private static VolumePanel _instance;

    public static VolumePanel Instance {
        get {
            if (_instance == null)
                _instance = FindObjectOfType<VolumePanel>();
            if (_instance == null)
                Debug.LogError("UserControlPanel not found");
            return _instance;
        }
    }

    #endregion Getter

    private void Awake() {
        name = "VolumePanel";
        rectTransform = GetComponent<RectTransform>();
        gameObject.transform.position = new Vector3(0, 0, 0);
    }
}
