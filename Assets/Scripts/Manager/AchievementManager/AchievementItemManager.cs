using System;
using UnityEngine;
using UnityEngine.UI;

public class AchievementItemManager : MonoBehaviour {
    [SerializeField] public Image iconUnlock;
    [SerializeField] public Image iconLocked;
    [SerializeField] public Text labelTitle;
    [SerializeField] public Text labelDescription;

    public bool unlocked;
    public Achievement achievement;

    public void RefreshView() {
        labelTitle.text = achievement.title;
        labelDescription.text = achievement.description;

        iconUnlock.enabled = unlocked;
        iconLocked.enabled = !unlocked;
    }

    private void OnValidate() {
        RefreshView();
    }
}
