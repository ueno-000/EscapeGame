using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject button;
    public AudioSource m_sound;
    int counter = 0;
    const int counterMax = 20; //最大値

    void Start()
    {
        button.SetActive(false);
        m_sound = GetComponent<AudioSource>();
    }

    //OnTriggerStay関数
    //接触したオブジェクトが引数otherとして渡される
    private void OnTriggerStay2D(Collider2D other)
    {
        //接触しているオブジェクトのタグが"Player"のとき
        if (other.CompareTag("Player"))
        {
            //オブジェクトの色を赤に変更する
            GetComponent<Renderer>().material.color = Color.red;
            button.SetActive(true);
        }
    }

    //OnTriggerExit関数
    //離れたオブジェクトが引数otherとして渡される
    void OnTriggerExit2D(Collider2D other)
    {
        //離れたオブジェクトのタグが"Player"のとき
        if (other.CompareTag("Player"))
        {
            //オブジェクトの色を赤に変更する
            GetComponent<Renderer>().material.color = Color.yellow;
            button.SetActive(false);
        }
    }

    // ボタンが押された場合、今回呼び出される関数
    public void OnClick()
    {
        button.SetActive(true);
        m_sound.PlayOneShot(m_sound.clip);
    }
    public void DeleteButton()
    {
        button.SetActive(false);
    }

}