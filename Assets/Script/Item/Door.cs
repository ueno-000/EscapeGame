using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : ItemBase
{
    /// <summary>Itemの選択回数のカウント</summary>
    [SerializeField] GameManager gamemanager;
    public override void OnPlayerSearch1()
    {
        if (!m_isChecked)
        {
            Debug.Log("入ってきた扉だ");
            TextController.Instance.DisplayText("入ってきた扉だ\r\n外は暗いから出ないでおこう", true);
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
            Debug.Log("入ってきた扉だ、調べる必要はなさそうだ");
            TextController.Instance.DisplayText("入ってきた扉だ\r\n外は暗いから出ないでおこう", true);
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
