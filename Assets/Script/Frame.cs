using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour
{
    [SerializeField] GameObject m_wall;


    void Start()
    {
        m_wall.SetActive(false);
    }

    //OnTriggerStay関数
    //接触したオブジェクトが引数otherとして渡される
    private void OnTriggerStay2D(Collider2D other)
    {
        //接触しているオブジェクトのタグが"Player"のとき
        if (other.CompareTag("Player"))
        {
            m_wall.SetActive(true);
        }
    }

    //OnTriggerExit関数
    //離れたオブジェクトが引数otherとして渡される
    void OnTriggerExit2D(Collider2D other)
    {
        //離れたオブジェクトのタグが"Player"のとき
        if (other.CompareTag("Player"))
        {
            m_wall.SetActive(false);
        }
    }

    // ボタンが押された場合、今回呼び出される関数
    public void OnClick()
    {
        m_wall.SetActive(true);
    }
    public void DeleteButton()
    {
        m_wall.SetActive(false);
    }
}
