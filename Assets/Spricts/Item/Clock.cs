using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : ItemBase
{
    public override void OnPlayerSearch1()
    {
        if (!m_isChecked)
        {
            Debug.Log("時計を調べてみた");
            //TextController.Instance.DisplayText("なにか見つけた");
            m_isChecked = true;
            m_selectButton.SetActive(false);
            //if (m_isMustItem)
            //{
            //    GameManager.Instance.AddItem();
            //}
        }
    }
}
