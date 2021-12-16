using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

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
        DontDestroyOnLoad(gameObject);
    }

    public void NextLevel() {
        Level += 1;
        SceneManager.LoadScene((int) SceneEnum.FirstPlan);
    }

    public void ResetLevel() {
        Level = 1;
    }
}
