using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBase<GameManager>
{
    public delegate void CakeAddDelegate();
    public event CakeAddDelegate cakeAddHandler = default;

    public delegate void CakeRemoveDelegate();
    public event CakeRemoveDelegate cakeRemoveHandler = default;

    public int Life = default;
    public new void Awake()
    {
        base.Awake();
        GFunc.sceneLoaded(OnSceneLoaded);
        init();
    }

    public void init()
    {
        Life = 8;
    }

    public void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case GData.INIT_SCENE_NAME:
                GFunc.LoadScene(GData.TITLE_SCENE_NAME);
                break;
            case GData.TITLE_SCENE_NAME:
                break;
            case GData.PLAY_SCENE_NAME:
                // 로드된 씬이 플레이 씬이다
                // 이곳에서 Tmp_Text 찾아서 할당
                break;
            default:
                break;
        }
    }

    public void PickUpCake()
    {
        cakeRemoveHandler();
    }
    public void CakeAdd()
    {
        cakeAddHandler();
    }

}
