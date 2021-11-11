using System.Collections.Generic;
using UnityEngine;

public class AchievementGlobalManager : MonoBehaviour {
    public static AchievementGlobalManager Instance { get; private set; }
    public AchievementsDatabase database;
    public AchievementsNotificationManager achievementsNotificationManager;
    [SerializeField] [HideInInspector] public List<AchievementItemManager> listAchievementItemManagers;
    public GameObject achievementItemPrefab;
    public Transform content;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        LoadAchievement();
    }

    private void LoadAchievement() {
        foreach (AchievementItemManager achievementItemManager in listAchievementItemManagers) {
            DestroyImmediate(achievementItemManager.gameObject);
        }

        listAchievementItemManagers.Clear();

        foreach (Achievement achievement in database.achievements) {
            GameObject gameObject = Instantiate(achievementItemPrefab, content);
            AchievementItemManager achievementItemManager = gameObject.GetComponent<AchievementItemManager>();
            bool unlock = PlayerPrefs.GetInt(ConstantManager.Achievement + achievement.id) == 1;
            achievementItemManager.achievement = achievement;
            achievementItemManager.unlocked = unlock;
            achievementItemManager.RefreshView();
            listAchievementItemManagers.Add(achievementItemManager);
        }
    }

    public void ShowNotification(AchievementsEnum achievementToShow) {
        Achievement achievement = database.achievements[(int) achievementToShow];
        achievementsNotificationManager.ShowNotification(achievement);
    }

    public void UnlockAchievement(AchievementsEnum achievementsEnum) {
        AchievementItemManager item = listAchievementItemManagers[(int) achievementsEnum];
        if (item.unlocked)
            return;
        ShowNotification(achievementsEnum);
        PlayerPrefs.SetInt(ConstantManager.Achievement + item.achievement.id, 1);
        item.unlocked = true;
    }

    public void LockAllAchievement() {
        foreach (Achievement achievement in database.achievements) {
            PlayerPrefs.DeleteKey(ConstantManager.Achievement + achievement.id);
        }

        foreach (AchievementItemManager itemManager in listAchievementItemManagers) {
            itemManager.unlocked = false;
        }
    }
}
