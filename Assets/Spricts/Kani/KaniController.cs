using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaniController : MonoBehaviour
{
    /// <summary>sameが当たった時に表示されるエフェクト</summary>
    [SerializeField] GameObject m_effectPrefab = default;
    /// <summary> HP</summary>
    [SerializeField] int Hp = 0;
    /// <summary>Deathエフェクトのプレハブ</summary>
    [SerializeField] GameObject m_explosionPrefab = null;
    /// <summary>Itemの選択回数のカウント</summary>
    [SerializeField] KeyController keyController;
    [SerializeField] bool KeyKani;
    Animator m_anim = default;

    void Start()
    {
        m_anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Same")
        {
            m_anim.SetTrigger("Damage");
            Hp--;
            //エフェクトとなるプレハブが設定されていたら、それを生成する
            if (m_effectPrefab)
            {
                Instantiate(m_effectPrefab, this.transform.position, this.transform.rotation);
            }

            // 自分自身を破棄する
            if (Hp < 1)
            {
                Debug.Log("カニを倒した");
                //KeyKaniにチェックが入っていた場合の処理
                if(KeyKani==true)
                {
                    Debug.Log("鍵を手に入れた");
                    keyController.KeyCount++;

                }
                // 爆発エフェクトを生成する
                if (m_explosionPrefab)
                {
                    Instantiate(m_explosionPrefab, this.transform.position, m_explosionPrefab.transform.rotation);
                }
                Destroy(this.gameObject);       // そして自分も破棄する
            }
        }
    }

}
