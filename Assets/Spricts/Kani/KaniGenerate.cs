using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaniGenerate : MonoBehaviour
{
    /// <summary>一定時間おきに生成する GameObject の元となるプレハブ</summary>
    [SerializeField] GameObject m_prefab = default;
    /// <summary>一定時間おきに生成する GameObject の元となるプレハブ</summary>
    [SerializeField] GameObject m_Keyprefab = default;
    /// <summary>生成する間隔（秒）</summary>
    [SerializeField] float m_interval = 1f;
    //X座標の最小値
    [SerializeField] float xMinPosition = -10f;
    //X座標の最大値
    [SerializeField] float xMaxPosition = 10f;
    /// <summary>true の場合、開始時にまず生成する</summary>
    [SerializeField] bool m_generateOnStart = true;
    /// <summary>タイマー計測用変数</summary>
    float m_timer;

    void Start()
    {
        if (m_generateOnStart)
        {
            m_timer = m_interval;
        }
    }

    void Update()
    {
        // Time.deltaTime は「前フレームからの経過時間」を取得する
        // これを積算して「経過時間」を求めるのは Unity での典型的なプログラミングのパターンである
        m_timer += Time.deltaTime;

        // 「経過時間」が「生成する間隔」を超えたら
        if (m_timer > m_interval)
        {
            m_timer = 0;    // タイマーをリセットしている
            //enemyをインスタンス化する(生成する)
            GameObject enemy = Instantiate(m_prefab);
            //生成した敵の位置をランダムに設定する
            enemy.transform.position = GetRandomPosition();
        }
    }
    private Vector3 GetRandomPosition()
    {
        //それぞれの座標をランダムに生成する
        float x = Random.Range(xMinPosition, xMaxPosition);

        //Vector3型のPositionを返す
        return new Vector3(x,5);
    }

}
