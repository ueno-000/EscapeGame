using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Sound))]
public class SoundManager : MonoBehaviour
{
    static SoundManager m_instance = default;
    public static SoundManager Instance => m_instance;
    private SoundManager() { }

    public AudioSource m_sourceSE;

    AudioClip m_mouseEnter = null;
    AudioClip m_click = null;

    private void Awake()
    {
        m_mouseEnter = GetComponent<Sound>().m_mouseEnter;
        m_click = GetComponent<Sound>().m_click;

        var go = GameObject.FindObjectsOfType<SoundManager>();
        m_instance = this;
    }
    /// <summary>声を再生する</summary>
    /// <param name="voice">AudioClip</param>



    /// <summary>マウスカーソルが重なった時に音を鳴らす</summary>
    public void MouseEnterSound()
    {
        m_sourceSE.PlayOneShot(m_mouseEnter);
    }

    /// <summary>クリックした時に音を鳴らす</summary>
    public void ObjectClicked()
    {
        m_sourceSE.PlayOneShot(m_click);
    }
}
