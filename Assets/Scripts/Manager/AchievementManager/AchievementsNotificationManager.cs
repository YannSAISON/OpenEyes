using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class AchievementsNotificationManager : MonoBehaviour {
    [SerializeField] public Text achievementTitleLabel;

    private Animator m_Animator;

    private void Awake() {
        m_Animator = GetComponent<Animator>();
    }

    public void ShowNotification(Achievement achievement) {
        achievementTitleLabel.text = achievement.title;
        m_Animator.SetTrigger("Appear");
    }
}
