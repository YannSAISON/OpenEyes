using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AchievementManager : ASceneManager {
    // public static AchievementManager Instance { get; private set; }
    public AchievementsNotificationManager achievementsNotificationManager;
    public AchievementDropdownManager achievementDropdownManager;
    public AchievementsEnum achievementToShow;

    public GameObject achievementItemPrefab;
    public Transform content;

    [SerializeField] [HideInInspector] private List<AchievementItemManager> listAchievementItemManagers;


    private void Start() {
        achievementDropdownManager.OnValuesChange += HandleAchievementDropdownValueChanged;
        LoadAchievementScrollView();
    }

    public void ShowNotification() {
        AchievementGlobalManager.Instance.ShowNotification(achievementToShow);
    }

    private void HandleAchievementDropdownValueChanged(AchievementsEnum achievement) {
        achievementToShow = achievement;
    }

    [ContextMenu("LoadAchievementScrollView()")]
    private void LoadAchievementScrollView() {
        foreach (AchievementItemManager achievementItemManager in listAchievementItemManagers) {
            DestroyImmediate(achievementItemManager.gameObject);
        }

        listAchievementItemManagers.Clear();

        foreach (Achievement achievement in AchievementGlobalManager.Instance.database.achievements) {
            GameObject gameObject = Instantiate(achievementItemPrefab, content);
            AchievementItemManager achievementItemManager = gameObject.GetComponent<AchievementItemManager>();
            bool unlock = PlayerPrefs.GetInt(achievement.id) == 1;
            achievementItemManager.achievement = achievement;
            achievementItemManager.unlocked = unlock;
            achievementItemManager.RefreshView();
            listAchievementItemManagers.Add(achievementItemManager);
        }
    }

    public void UnlockAchievement() {
        UnlockAchievement(achievementToShow);
    }

    private void UnlockAchievement(AchievementsEnum achievementsEnum) {
        Debug.Log("UnlockAchievement" + achievementsEnum);
        AchievementItemManager item = listAchievementItemManagers[(int) achievementsEnum];
        if (item.unlocked)
            return;
        ShowNotification();
        PlayerPrefs.SetInt(item.achievement.id, 0);
        item.unlocked = true;
        item.RefreshView();
    }

    public void LockAllAchievement() {
        foreach (Achievement achievement in AchievementGlobalManager.Instance.database.achievements) {
            PlayerPrefs.DeleteKey(achievement.id);
        }

        foreach (AchievementItemManager itemManager in listAchievementItemManagers) {
            itemManager.unlocked = false;
            itemManager.RefreshView();
        }
    }
}
