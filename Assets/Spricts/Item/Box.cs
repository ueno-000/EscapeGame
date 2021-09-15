using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : ItemBase
{
    /// <summary>Itemの選択回数のカウント</summary>
    [SerializeField] GameManager gamemanager;

    public override void OnPlayerSearch1()
    {
        if (!m_isChecked)
        {
            Debug.Log("木箱を調べてみた");
            TextController.Instance.DisplayText("木箱だ\r\n何か入っている");
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
            TextController.Instance.DisplayText("木箱だ\r\nん？何か入っている");
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
