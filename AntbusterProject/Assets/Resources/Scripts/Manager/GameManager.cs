using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : SingletonBase<GameManager>
{
    public int Life = default;
    public new void Awake()
    {
        base.Awake();
        SceneManager.sceneLoaded += OnSceneLoaded;
        init();
    }


    public void init()
    {
        Life = 8;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case GData.INIT_SCENE_NAME:
                GFunc.LoadScene(GData.TITLE_SCENE_NAME);
                break;
            case GData.TITLE_SCENE_NAME:
                break;
            case GData.PLAY_SCENE_NAME:
                break;
            default:
                break;
        }
    }
}
