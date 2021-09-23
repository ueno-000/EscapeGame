using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaniController : MonoBehaviour
{
    /// <summary>sameが当たった時に表示されるエフェクト</summary>
    [SerializeField] GameObject m_effectPrefab = default;
    /// <summary> HP</summary>
    [SerializeField] int Hp = 0;
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
            //if (m_effectPrefab)
            //{
            //    Instantiate(m_effectPrefab, this.transform.position, this.transform.rotation);
            //}

            // 自分自身を破棄する
            if (Hp == 0)
            {
                Destroy(this.gameObject);
            }

        }
    }
}
