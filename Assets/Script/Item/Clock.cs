using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : ItemBase
{
    /// <summary>Itemの選択回数のカウント</summary>
    [SerializeField] GameManager gamemanager;
    public override void OnPlayerSearch1()
    {
        if (!m_isChecked)
        {
            Debug.Log("時計を調べてみた");
            TextController.Instance.DisplayText("針は0時を指して止まっている", true);
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
            Debug.Log("時計を調べてみた");
            TextController.Instance.DisplayText("針は0時を指して止まっている", true);
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
