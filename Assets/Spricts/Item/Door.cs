using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : ItemBase
{
    public override void OnPlayerSearch1()
    {
        if (!m_isChecked)
        {
            Debug.Log("入ってきた扉だ");
            //TextController.Instance.DisplayText("なにか見つけた");
            m_isChecked = true;
            m_selectButton.SetActive(false);
            //if (m_isMustItem)
            //{
            //    GameManager.Instance.AddItem();
            //}
        }
    }
    public override void OnPlayerSearch2()
    {
        if (!m_isChecked)
        {
            Debug.Log("入ってきた扉だ、調べる必要はなさそうだ");
            //TextController.Instance.DisplayText("調べてみてもよかったかもしれない");
            m_isChecked = true;
            m_selectButton.SetActive(false);
            //if (m_isMustItem)
            //{
            //    GameManager.Instance.AddItem();
            //}
        }
    }
}
