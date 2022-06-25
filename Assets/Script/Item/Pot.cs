using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : ItemBase
{
    /// <summary>Itemの選択回数のカウント</summary>
    [SerializeField] GameManager gamemanager;
    public override void OnPlayerSearch1()
    {
        if (!m_isChecked)
        {
            Debug.Log("植木鉢を調べてみた");
            TextController.Instance.DisplayText("植物はもう枯れてる", true);
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
            TextController.Instance.DisplayText("虫がいるかも、、、\r\n触りたくない", true);
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
