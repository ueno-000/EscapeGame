using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocker : ItemBase
{
    /// <summary>Itemの選択回数のカウント</summary>
    [SerializeField] GameManager gamemanager;
    /// <summary>表示する画像</summary>
    [SerializeField] protected GameObject m_Image = null;

    public override void OnPlayerSearch1()
    {
        if (!m_isChecked)
        {
            Debug.Log("ロッカーを調べてみた");
            TextController.Instance.DisplayText("ロッカーの中にはサメが入っていた\r\nサメは私に着いて来たいようだ");
            m_isChecked = true;
            m_selectButton.SetActive(false);
            m_Image.SetActive(true);
            StartCoroutine("FadePanel");
            gamemanager.ItemCount++;
        }
    }
    public override void OnPlayerSearch2()
    {
        if (!m_isChecked)
        {
            Debug.Log("調べなかった");
            TextController.Instance.DisplayText("気になって開けたら、ロッカーにサメが入っていた\r\nサメは仲間になってくれるようだ");
            m_isChecked = true;
            m_selectButton.SetActive(false);
            m_Image.SetActive(true);
            StartCoroutine("FadePanel");
            gamemanager.ItemCount++;
        }
    }
    IEnumerator FadePanel()
    {
        yield return new WaitForSeconds(4f);
        m_Image.SetActive(false);
    }
}
