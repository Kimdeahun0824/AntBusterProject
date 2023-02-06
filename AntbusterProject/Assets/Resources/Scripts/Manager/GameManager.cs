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
                // 로드된 씬이 플레이 씬이다
                // 이곳에서 Tmp_Text 찾아서 할당
                break;
            default:
                break;
        }
    }
}

public class test
{
    public delegate void TEST<T0, T1>(T0 t1, T1 t2);
    public static event TEST<string, string> delegateTest;
    // public delegate void Test(int num);
    // public static event Test delegateTest;

    public void main()
    {
        delegateTest += asdf;
    }
    public void asdf(string a, string b)
    {
        return;
    }
}

