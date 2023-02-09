using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountText : MonoBehaviour
{
    private int count = default;

    void Start()
    {
        count = 10;
        StartCoroutine(StartCount());
    }

    IEnumerator StartCount()
    {
        while (true)
        {
            gameObject.SetTmpText("" + count);
            yield return new WaitForSeconds(1.0f);
            if (count == 0)
            {
                GameManager.Instance.GameStart();
                gameObject.SetActive(false);
                break;
            }
            count--;
        }
    }

}
