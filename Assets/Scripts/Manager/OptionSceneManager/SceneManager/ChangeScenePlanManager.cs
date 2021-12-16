using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenePlanManager : MonoBehaviour
{
    public static ChangeScenePlanManager instance = null;

    public SceneEnum m_scene;
    public int m_warpId;

    public int respawnSceneId;

    public GameObject player;
    public GameObject[] warpArray;

    public int currentWarpId;
    private bool isFirstAwakening = true;

    void Awake()
    {
        //GameObject[] objs = GameObject.FindGameObjectsWithTag("SceneChangeManager");

        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        if (warpArray.Length == 0)
            warpArray = GameObject.FindGameObjectsWithTag("Warp");
        if (respawnSceneId == 0)
        {
            respawnSceneId = SceneManager.GetActiveScene().buildIndex;
            Debug.Log("Respawn scene erased, replacing by" + respawnSceneId);
        }
        DontDestroyOnLoad(gameObject);

    }

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (isFirstAwakening == true)
        {
            isFirstAwakening = false;
            return;
        }
        player = GameObject.FindGameObjectWithTag("Player");
        warpArray = GameObject.FindGameObjectsWithTag("Warp");
        foreach (GameObject warp in warpArray)
        {
            if (warp.GetComponent<Warp>().warpId == currentWarpId)
            {
                player.transform.position = new Vector3(warp.transform.position.x, warp.transform.position.y, 0);
                break;
            }
        }
    }

public void LoadScene(SceneEnum scene, int warpId, Collider2D player)
    {
        currentWarpId = warpId;

        m_scene = scene;
        SceneManagerController.Load(scene);
    }
}
