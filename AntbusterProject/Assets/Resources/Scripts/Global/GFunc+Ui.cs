using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public static partial class GFunc
{
    //! �ؽ�Ʈ�޽����� ������ ������Ʈ�� �ؽ�Ʈ�� �����ϴ� �Լ�
    public static void SetTmpText(this GameObject obj_, string text_)
    {
        TMP_Text tmpTxt = obj_.GetComponent<TMP_Text>();
        if (tmpTxt == null || tmpTxt == default(TMP_Text))
        {
            return;
        }       // if: ������ �ؽ�Ʈ�޽� ������Ʈ�� ���� ���

        // ������ �ؽ�Ʈ�޽� ������Ʈ�� �����ϴ� ���
        tmpTxt.text = text_;
    }       // SetTextMeshPro()

    public static void SetFilledAmount(this GameObject obj_, float amount)
    {
        Image image = obj_.GetComponent<Image>();
        image.fillAmount = amount;
    }

    public static void ImageActive(this GameObject obj_, bool active)
    {
        obj_.GetComponent<Image>().enabled = active;
    }
}
