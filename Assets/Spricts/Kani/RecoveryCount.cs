using UnityEngine;
using UnityEngine.UI;

public class RecoveryCount : MonoBehaviour
{
    // スコアを表示する
    public Text scoreText;
    /// <summary>回復できる回数 </summary>
    int m_recoveryCount = 10;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            m_recoveryCount--;
        }
        if(m_recoveryCount <= 0)
        {
            m_recoveryCount = 0;
        }
        // スコア・ハイスコアを表示する
        scoreText.text =　"残り携帯食料"+"\r"+m_recoveryCount.ToString();

    }

}
