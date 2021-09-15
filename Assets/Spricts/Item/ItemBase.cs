using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBase : MonoBehaviour
{
    /// <summary>マウスカーソルが重なった際に表示するSprite</summary>
    [SerializeField] protected GameObject m_backGround = null;
    /// <summary>マウスカーソルが重なった際に表示するSprite</summary>
    //[SerializeField] protected GameObject m_girl = null;
    /// <summary>行動を決めるメニュー(Button)</summary>
    [SerializeField] protected GameObject m_selectButton = null;
    /// <summary>ゲームクリアに必要なアイテムかのフラグ</summary>
    [SerializeField] protected bool m_isMustItem = false;
    /// <summary>探索済みかのフラグ</summary>
    [SerializeField] protected bool m_isChecked = false;
    /// <summary>プレイヤーの音声</summary>
    [SerializeField] protected AudioClip m_playerVoice = null;
    ///// <summary>バディの音声</summary>
    //[SerializeField] protected AudioClip m_badyVoice = null;
    /// <summary>Item</summary>
    //[SerializeField] GameManager gamemanager; 
    public bool IsMustItem => m_isMustItem;

    private void Start()
    {
        if (!m_backGround)
        {
            Debug.LogWarning("背後の絵をアサインしてください");
        }
        if (!m_selectButton)
        {
            Debug.LogWarning("選択ボタンをアサインしてください");
        }
    }

    /// <summary>マウスカーソルが重なった時に呼ばれるメソッド</summary>
    public void OnMouseEnter()   // Unityの既存のメソッドとは違う。
    {
        if (m_backGround)
        {
            m_backGround.SetActive(true);     // 背後の絵を非表示にする
        }
        //SoundManager.Instance.MouseEnterSound();
    }

    /// <summary>マスカーソルが離れた時に呼ばれるメソッド</summary>
    public void OnMouseExit()   // Unityの既存のメソッドとは違う。
    {
        if (m_backGround)
        {
            m_backGround.SetActive(false);   // 背後の絵を表示する
        }
    }

    /// <summary>アイテムがクリックした時に呼ばれるメソッド</summary>
    public void OnClick()
    {
        Debug.Log("アイテムを選択した");
        if (!m_isChecked)
        {
            m_selectButton.SetActive(true);
        }
        //SoundManager.Instance.ObjectClicked();
    }

    /// <summary>捜索1のメソッド</summary>
    public virtual void OnPlayerSearch1()
    {
        Debug.Log("調べたが何もなかった");
        TextController.Instance.DisplayText("調べたが何もなかった");
        m_selectButton.SetActive(false);
        //gamemanager.ItemCount++;
    }

    /// <summary>捜索2のメソッド</summary>
    public virtual void OnPlayerSearch2()
    {
        Debug.Log("調べなかった");
        //GameManager.Instance.m_girl.SetActive(true);
        //GameManager.Instance.Sets();
        //SoundManager.Instance.OnPlayVoice(m_badyVoice);
         TextController.Instance.DisplayText("調べなかった");
        m_selectButton.SetActive(false);
        //gamemanager.ItemCount++;
    }


    /// <summary>探索が終わった際に呼ばれる関数</summary>
    protected void StateChenge()
    {
        m_isChecked = true;
    }
}
