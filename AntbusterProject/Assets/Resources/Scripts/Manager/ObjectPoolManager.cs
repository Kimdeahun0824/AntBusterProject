using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : SingletonBase<ObjectPoolManager>
{
    private Stack<GameObject> objPool = default;
    public GameObject obj = default;
    public int objCount = default;
    public new void Awake()
    {
        base.Awake();
        objPool = new Stack<GameObject>();
    }

    private void ObjPoolCreator(Transform parent_, GameObject obj_, int objCount_)
    {

    }
    private void ObjPoolCreator(Transform parent_, GameObject obj_)
    {

    }
    private void ObjPoolCreator(Transform parent_)
    {

    }
}
