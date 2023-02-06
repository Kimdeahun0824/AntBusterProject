using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Btn : MonoBehaviour
{
    public void OnPlayBtnClick()
    {
        GFunc.LoadScene(GData.PLAY_SCENE_NAME);
    }
}
