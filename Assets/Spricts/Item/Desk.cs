using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : ItemBase
{
    /// <summary>Itemの選択回数のカウント</summary>
    [SerializeField] GameManager gamemanager;
    /// <summary>表示する画像</summary>
    [SerializeField] protected GameObject m_Image = null;

    public override void OnPlayerSearch1()
    {
        if (!m_isChecked)
        {
            Debug.Log("机を調べてみた");
            TextController.Instance.DisplayText("机の裏にあった\r\n懐中電灯をみつけた");
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
            TextController.Instance.DisplayText("机の裏に何か見えた\r\n懐中電灯？");
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
