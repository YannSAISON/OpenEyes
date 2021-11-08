using UnityEngine;

public class AchievementGlobalManager : MonoBehaviour {
    public static AchievementGlobalManager Instance { get; private set; }
    public AchievementsDatabase database;
    public AchievementsNotificationManager achievementsNotificationManager;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void ShowNotification(AchievementsEnum achievementToShow) {
        Achievement achievement = database.achievements[(int) achievementToShow];
        achievementsNotificationManager.ShowNotification(achievement);
    }
}
