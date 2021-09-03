using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    /// <summary>マスカーソルが重なった時にならす音</summary>
    [SerializeField] public AudioClip m_mouseEnter;
    /// <summary>クリック音</summary>
    [SerializeField] public AudioClip m_click;

    private void Start()
    {
        if (!m_mouseEnter)
        {
            Debug.LogError("効果音をアサインしてください");
        }
        if (!m_click)
        {
            Debug.LogError("効果音をアサインしてください");
        }
    }
}
