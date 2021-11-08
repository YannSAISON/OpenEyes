using System.Collections.Generic;
using UnityEngine;
using Malee.List;

[CreateAssetMenu()]
public class AchievementsDatabase : ScriptableObject {
    [Reorderable(sortable = false, paginate = false)]
    public List<Achievement> achievements;

    [System.Serializable]
    public class AchievementsArray : ReorderableArray<Achievement> {
    }
}
