using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : ItemBase
{
    /// <summary>Itemの選択回数のカウント</summary>
    [SerializeField] GameManager gamemanager;
    /// <summary>表示する画像</summary>
    [SerializeField] protected GameObject m_Image = null;

    public override void OnPlayerSearch1()
    {
        if (!m_isChecked)
        {
            Debug.Log("調べてみた");
            TextController.Instance.DisplayText("新聞紙だ\r\n読んでみるか", true);
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
            TextController.Instance.DisplayText("新聞紙のようだ\r\n読んでみよう", true);
            m_isChecked = true;
            m_selectButton.SetActive(false);
            m_Image.SetActive(true);
            StartCoroutine("FadePanel");
            gamemanager.ItemCount++;
        }
    }
    IEnumerator FadePanel()
    {
        yield return new WaitForSeconds(6f);
        m_Image.SetActive(false);
    }
}
