using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaniGenerate : MonoBehaviour
{
    /// <summary>一定時間おきに生成する カニのプレハブ</summary>
    [SerializeField] GameObject m_prefab = default;
    /// <summary>生成する間隔（秒）</summary>
    [SerializeField] float m_interval = 1f;
    /// <summary>true の場合、開始時にまず生成する</summary>
    [SerializeField] bool m_generateOnStart = true;
    /// <summary>タイマー計測用変数</summary>
    float m_timer;

    void Start()
    {
        StartCoroutine("KeyKaniCount");
    }

    IEnumerator KeyKaniCount()
    {
        for (int count = 0; count < 20; count++)
        {
            //秒おきに生成する
            yield return new WaitForSeconds(m_interval);
            //カニをインスタンス化する(生成する)
            GameObject KeyKani = Instantiate(m_prefab);
            //生成した敵の位置をランダムに設定する
            KeyKani.transform.position = GetRandomPosition();
        }
    }
    private Vector3 GetRandomPosition()
    {
        //それぞれの座標をランダムに生成する
        float x = Random.Range(-40, 40);

        //Vector3型のPositionを返す
        return new Vector3(x,5);
    }

}
