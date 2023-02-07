using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cake : MonoBehaviour
{
    public int cakeLife = default;
    private Image cakeObj = default;
    public Sprite[] cakeSprite = default;


    public void Start()
    {
        GameManager.Instance.cakeAddHandler += CakeAdd;
        GameManager.Instance.cakeRemoveHandler += CakeRemove;
        cakeObj = transform.GetChild(0).GetComponent<Image>();
        CakeImageSet();
    }

    // Cake의 Sprite를 교체해주는 함수
    public void CakeImageSet()
    {
        cakeObj.sprite = cakeSprite[cakeLife - 1];
    }

    // Cake를 추가할때의 함수
    public void CakeAdd()
    {
        if (8 <= cakeLife) return;
        cakeLife++;
        CakeImageSet();
    }

    // Cake를 제거할때의 함수
    public void CakeRemove()
    {
        if (cakeLife <= 0) return;
        cakeLife--;
        CakeImageSet();
    }

}
