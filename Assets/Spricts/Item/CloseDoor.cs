using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : ItemBase
{
    /// <summary>Itemの選択回数のカウント</summary>
    [SerializeField] GameManager gamemanager;
    public override void OnPlayerSearch1()
    {
        if (!m_isChecked)
        {
            Debug.Log("開かずの扉を調べてみた");
            TextController.Instance.DisplayText("、、、、、、、\r\n開かないみたい");
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
            TextController.Instance.DisplayText("ふさいでる木材、、\r\n古びてるし触りたくない");
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
