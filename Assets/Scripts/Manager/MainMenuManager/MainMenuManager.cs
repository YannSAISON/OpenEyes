using System;
using UnityEngine;

public class MainMenuManager : ASceneManager {
    private static MainMenuManager _instance;

    #region Getter

    public static MainMenuManager Instance {
        get {
            if (_instance == null)
                _instance = FindObjectOfType<MainMenuManager>();
            if (_instance == null)
                Debug.LogError("MainMenuManager not found");
            return _instance;
        }
    }

    #endregion Getter

    private void Awake() {
    }

    private void Start() {
    }

    private void Update() {
    }
}
