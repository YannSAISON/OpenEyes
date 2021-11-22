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

        foreach (AchievementItemManager item in AchievementGlobalManager.Instance.listAchievementItemManagers) {
            GameObject gameObject = Instantiate(achievementItemPrefab, content);
            AchievementItemManager achievementItemManager = gameObject.GetComponent<AchievementItemManager>();
            bool unlock = PlayerPrefs.GetInt(ConstantManager.Achievement + item.achievement.id) == 1;
            achievementItemManager.achievement = item.achievement;
            achievementItemManager.unlocked = unlock;
            achievementItemManager.RefreshView();
            listAchievementItemManagers.Add(achievementItemManager);
        }
    }

    public void UnlockAchievement() {
        AchievementGlobalManager.Instance.UnlockAchievement(achievementToShow);
        UnlockAchievement(achievementToShow);
    }

    private void UnlockAchievement(AchievementsEnum achievementsEnum) {
        AchievementItemManager item = listAchievementItemManagers[(int) achievementsEnum];
        if (item.unlocked)
            return;
        item.unlocked = true;
        item.RefreshView();
    }

    public void LockAllAchievement() {
        AchievementGlobalManager.Instance.LockAllAchievement();
        foreach (AchievementItemManager itemManager in listAchievementItemManagers) {
            itemManager.unlocked = false;
            itemManager.RefreshView();
        }
    }
}
