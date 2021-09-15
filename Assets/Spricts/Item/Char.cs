using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char : ItemBase
{
    /// <summary>Itemの選択回数のカウント</summary>
    [SerializeField] GameManager gamemanager;

    public override void OnPlayerSearch1()
    {
        if (!m_isChecked)
        {
            Debug.Log("調べてみた");
            TextController.Instance.DisplayText("椅子だ");
            m_isChecked = true;
            m_selectButton.SetActive(false);
            //if (m_isMustItem)
            //{
            //    GameManager.Instance.AddItem();
            //}
            gamemanager.ItemCount++;
        }
    }
    public override void OnPlayerSearch2()
    {
        if (!m_isChecked)
        {
            Debug.Log("調べなかった");
            TextController.Instance.DisplayText("見ればわかる\r\n椅子だ");
            m_isChecked = true;
            m_selectButton.SetActive(false);
            //if (m_isMustItem)
            //{
            //    GameManager.Instance.AddItem();
            //}
            gamemanager.ItemCount++;
        }
    }
}
