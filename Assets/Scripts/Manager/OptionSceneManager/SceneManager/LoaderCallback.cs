using UnityEngine;

public class LoaderCallback : MonoBehaviour {
    private bool m_IsFirstUpdate = true;

    private void Update() {
        if (m_IsFirstUpdate) {
            m_IsFirstUpdate = false;
            SceneManagerController.LoadCallback();
        }
    }
}
