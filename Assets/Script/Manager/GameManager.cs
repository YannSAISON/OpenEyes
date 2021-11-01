using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }
    private SceneEnum ActualScene { get; set; }
    public SceneEnum LatestScene { get; private set; }

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
        ActualScene = SceneEnum.OpeningScene;
        LatestScene = SceneEnum.OpeningScene;
    }
}
