using System.Collections.Generic;
using UnityEngine;

public class AchievementGlobalManager : MonoBehaviour {
    public static AchievementGlobalManager Instance { get; private set; }
    public AchievementsDatabase database;
    public AchievementsNotificationManager achievementsNotificationManager;
    [SerializeField] [HideInInspector] private List<AchievementItemManager> listAchievementItemManagers;

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
            AchievementItemManager itemManager = gameObject.AddComponent<AchievementItemManager>();
            bool unlock = PlayerPrefs.GetInt(ConstantManager.Achievement + achievement.id) == 1;
            itemManager.achievement = achievement;
            itemManager.unlocked = unlock;
            listAchievementItemManagers.Add(itemManager);
        }
    }

    public void ShowNotification(AchievementsEnum achievementToShow) {
        Achievement achievement = database.achievements[(int) achievementToShow];
        AchievementItemManager item = listAchievementItemManagers[(int) achievementToShow];
        PlayerPrefs.SetInt(ConstantManager.Achievement + achievement.id, 0);
        item.unlocked = true;
        achievementsNotificationManager.ShowNotification(achievement);
    }

    private void UnlockAchievement(AchievementsEnum achievementsEnum) {
        AchievementItemManager item = listAchievementItemManagers[(int) achievementsEnum];
        if (item.unlocked)
            return;
        ShowNotification(achievementsEnum);
        PlayerPrefs.SetInt(ConstantManager.Achievement + item.achievement.id, 0);
        item.unlocked = true;
    }
}
