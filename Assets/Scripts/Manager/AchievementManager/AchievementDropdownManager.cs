using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]
public class AchievementDropdownManager : MonoBehaviour {
    private Dropdown m_Dropdown;
    public Action<AchievementsEnum> OnValuesChange;

    private Dropdown Dropdown {
        get {
            if (m_Dropdown == null) {
                m_Dropdown = GetComponent<Dropdown>();
            }

            return m_Dropdown;
        }
    }

    private void Awake() {
        UpdateOptions();
        Dropdown.onValueChanged.AddListener(HandleDropdownValueChanged);
    }
    
    [ContextMenu("UpdateOptions()")]
    private void UpdateOptions() {
        Array values = Enum.GetValues(typeof(AchievementsEnum));

        Dropdown.options.Clear();
        foreach (AchievementsEnum achievement in values) {
            Dropdown.options.Add(new Dropdown.OptionData(achievement.ToString()));
        }

        Dropdown.RefreshShownValue();
    }

    private void HandleDropdownValueChanged(int value) {
        OnValuesChange?.Invoke((AchievementsEnum) value);
    }
}
