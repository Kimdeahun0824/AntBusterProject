using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBase<GameManager>
{
    public delegate void CakeAddDelegate();
    public event CakeAddDelegate cakeAddHandler = default;

    public delegate void CakeRemoveDelegate();
    public event CakeRemoveDelegate cakeRemoveHandler = default;
    //public List<GameObject> ants = default;

    public int money = default;
    public int score = default;
    public int level = default;

    public int cakeLife = default;

    new void Awake()
    {
        base.Awake();

        init();
    }

    public void init()
    {
        GFunc.sceneLoaded(OnSceneLoaded);
        cakeLife = 8;
        //ants = new List<GameObject>();
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

    public void GameStart()
    {
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            GameObject tempObj = ObjectPoolManager.Instance.ObjPop(GData.ENEMY_ANT_NAME);
            if (tempObj == null) continue;
            tempObj.transform.localPosition = new Vector3(20f, -20f, 0f);
            tempObj.SetActive(true);
            //ants.Add(tempObj);

        }
    }


}
