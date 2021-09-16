using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : ItemBase
{
    /// <summary>Itemの選択回数のカウント</summary>
    [SerializeField] GameManager gamemanager;

    public override void OnPlayerSearch1()
    {
        if (!m_isChecked)
        {
            Debug.Log("窓を調べてみた");
            TextController.Instance.DisplayText("窓の下でカニが月光浴してる");
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
            TextController.Instance.DisplayText("月がきれいだなあ");
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
