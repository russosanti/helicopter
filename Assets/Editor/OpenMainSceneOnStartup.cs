using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public static class OpenMainSceneOnStartup
{
    private const string SessionKey = "Helicopter.MainSceneOpened";
    private const string MainScenePath = "Assets/Resources/Scenes/Main.unity";

    static OpenMainSceneOnStartup()
    {
        if (!SessionState.GetBool(SessionKey, false))
        {
            EditorApplication.delayCall += OpenMainScene;
        }
    }

    private static void OpenMainScene()
    {
        if (EditorApplication.isCompiling || EditorApplication.isUpdating)
        {
            EditorApplication.delayCall += OpenMainScene;
            return;
        }

        SessionState.SetBool(SessionKey, true);

        var scene = SceneManager.GetActiveScene();
        if (string.IsNullOrEmpty(scene.path)
            && scene.name == "Untitled"
            && scene.rootCount <= 2)
        {
            EditorSceneManager.OpenScene(MainScenePath, OpenSceneMode.Single);
        }
    }
}
