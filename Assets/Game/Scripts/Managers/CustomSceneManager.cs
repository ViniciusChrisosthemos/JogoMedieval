using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager
{
    public CustomSceneManager() { }

    public AsyncOperation LoadBattleScene()
    {
        return SceneManager.LoadSceneAsync(Scenes.BattleScene, LoadSceneMode.Additive);
    }

    public void LoadWorldScene()
    {
        SceneManager.LoadScene(Scenes.WorldScene);
    }

    public AsyncOperation UnloadBattleScene()
    {
        return SceneManager.UnloadSceneAsync(Scenes.BattleScene);
    }
}