using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    private ChangeScenePlanManager changeScenePlanManager;

    [SerializeField]
    private int level = 1;
    public int Level {
        private set {
            level = value;
        }
        get {
            return (level);
        }
    }

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
        changeScenePlanManager = FindObjectOfType<ChangeScenePlanManager>();
        DontDestroyOnLoad(gameObject);
    }

    public void NextLevel() {
        Level += 1;
        Debug.Log("Active scene = " + SceneManager.GetActiveScene().buildIndex);
        changeScenePlanManager.respawnSceneId = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResetLevel() {
        Level = 1;
    }
}
