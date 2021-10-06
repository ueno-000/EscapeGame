using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager2F : MonoBehaviour
{
    ///<summary>Player</summary>
    [SerializeField] GameObject m_Player = default;
    ///<summary>Player</summary>
    [SerializeField] GameObject m_TestPlayer = default;
    /// <summary>Sousa</summary>
    [SerializeField] GameObject m_prefab = default;
    /// <summary>Sousa</summary>
    [SerializeField] GameObject m_prefab2 = default;
    /// <summary>thisObject</summary>
    [SerializeField] GameObject m_Sllider = default;
    //public AudioSource m_sound;

    void Start()
    {
       // m_sound = GetComponent<AudioSource>();
        StartCoroutine("Girlcomment");
    }


    IEnumerator Girlcomment()
    {
        yield return new WaitForSeconds(2f);
        TextController.Instance.DisplayText("この道で合っているみたい");
        yield return new WaitForSeconds(2f);
        TextController.Instance.DisplayText("、、、！");
        yield return new WaitForSeconds(2f);
        TextController.Instance.DisplayText("カニが道をふさいでいる！");
        yield return new WaitForSeconds(2f);
        TextController.Instance.DisplayText("倒して進むしかなさそうだ！");
        StartCoroutine("Player");
    }
    IEnumerator Player()
    {
        yield return new WaitForSeconds(3f);
        m_Sllider.SetActive(true);
        m_TestPlayer.SetActive(false);
        m_Player.SetActive(true);
        m_prefab.SetActive(true);
        m_prefab2.SetActive(true);
    }
}
