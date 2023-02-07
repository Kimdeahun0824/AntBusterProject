using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : SingletonBase<ObjectPoolManager>
{
    private Dictionary<string, Stack<GameObject>> objPool = default;
    public List<string> objKeys = default;
    public List<GameObject> objvalues = default;
    public List<int> objCounts = default;

    new void Awake()
    {
        base.Awake();
        GFunc.sceneLoaded(OnSceneLoaded);
        objPool = new Dictionary<string, Stack<GameObject>>();
    }
    public void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        if (scene.name == GData.PLAY_SCENE_NAME)
        {
            Transform parent = GFunc.GetRootObj("GameObjs").transform;
            parent = parent.gameObject.FindChildObj("PlayGround").transform;
            parent = parent.gameObject.FindChildObj("Enemys").transform;
            ObjPoolCreator(objKeys[0], parent, objvalues[0], objCounts[0]);
        }
    }
    private void ObjPoolCreator(string objKey_, Transform parent_, GameObject obj_, int objCount_)
    {
        objPool[objKey_] = new Stack<GameObject>();
        for (int i = 0; i < objCount_; i++)
        {
            GameObject tempObj = Instantiate(obj_, parent_);
            tempObj.transform.localPosition = Vector3.zero;
            tempObj.SetActive(false);
            objPool[objKey_].Push(tempObj);
        }
    }
    private void ObjPoolCreator(Transform parent_, GameObject obj_)
    {

    }
    private void ObjPoolCreator(Transform parent_)
    {

    }

    public GameObject ObjPop(string objKey)
    {
        if (objPool[objKey].Count <= 0) return null;
        return objPool[objKey].Pop();
    }
    public void ObjPush(string objKey, GameObject obj)
    {
        obj.transform.localPosition = Vector3.zero;
        obj.SetActive(false);
        objPool[objKey].Push(obj);
    }
}
