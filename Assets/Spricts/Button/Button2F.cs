using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2F : MonoBehaviour
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
    public AudioSource m_sound;
    void Start()
    {
        m_sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GuideComment2()
    {
        TextController.Instance.DisplayText("日が昇ったから\r\n案内板にある灯台に向かって歩いてきた");
        m_sound.PlayOneShot(m_sound.clip);
        StartCoroutine("Start2F");
    }
    IEnumerator Start2F()
    {
        yield return new WaitForSeconds(4f);
        TextController.Instance.DisplayText("この標識を信じて灯台に向かおう");
        StartCoroutine("Kani");
    }
    IEnumerator Kani()
    {
        yield return new WaitForSeconds(5f);
        TextController.Instance.DisplayText("！、、、カ、カニ？？？");
        StartCoroutine("SameKani");
    }
    IEnumerator SameKani()
    {
        yield return new WaitForSeconds(4f);
        m_prefab.SetActive(true);
        m_prefab2.SetActive(true);
        TextController.Instance.DisplayText("前に進むにはカニを倒すしかなさそうだ！！");
        StartCoroutine("Player");
    }
    IEnumerator Player()
    {
        yield return new WaitForSeconds(3f);
        m_Sllider.SetActive(true);
        m_TestPlayer.SetActive(false);
        m_prefab.SetActive(false);
        m_prefab2.SetActive(false);
        m_Player.SetActive(true);
    }
}
