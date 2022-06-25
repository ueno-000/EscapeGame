using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waste : ItemBase

{
    /// <summary>Itemの選択回数のカウント</summary>
    [SerializeField] GameManager gamemanager;

    public override void OnPlayerSearch1()
    {
        if (!m_isChecked)
        {
            Debug.Log("調べてみた");
            TextController.Instance.DisplayText("紙くずだ", true);
            m_isChecked = true;
            m_selectButton.SetActive(false);
            gamemanager.ItemCount++;
        }
    }
    public override void OnPlayerSearch2()
    {
        if (!m_isChecked)
        {
            Debug.Log("調べなかった");
            TextController.Instance.DisplayText("紙くずだ\r\n触りたくはない", true);
            m_isChecked = true;
            m_selectButton.SetActive(false);
            gamemanager.ItemCount++;
        }
    }
}
