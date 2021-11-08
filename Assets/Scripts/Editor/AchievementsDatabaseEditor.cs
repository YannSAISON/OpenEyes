using System.IO;
using UnityEditor;
using UnityEngine;

namespace Editor {
    [CustomEditor(typeof(AchievementsDatabase))]
    public class AchievementsDatabaseEditor : UnityEditor.Editor {
        private AchievementsDatabase m_Database;

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            if (GUILayout.Button("Generate Enum", GUILayout.Height(30))) {
                GenerateEnum();
            }
        }

        private void OnEnable() {
            m_Database = target as AchievementsDatabase;
        }

        private void GenerateEnum() {
            string filePath = Path.Combine(Application.dataPath, "Scripts/Enum/AchievementsEnum.cs");
            string code = "public enum AchievementsEnum {\n";

            foreach (Achievement achievement in m_Database.achievements) {
                // Todo: Validate the format of the id
                code += "\t" + achievement.id + ",\n";
            }

            code += "}";
            File.WriteAllText(filePath, code);
            AssetDatabase.ImportAsset("Assets/Enum/AchievementsEnum.cs");
        }
    }
}
