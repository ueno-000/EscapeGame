using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class KaniController : MonoBehaviour
{
    /// <summary>sameが当たった時に表示されるエフェクト</summary>
    [SerializeField] GameObject m_effectPrefab = default;
    /// <summary> HP</summary>
    [SerializeField] int Hp = 0;
    /// <summary>Deathエフェクトのプレハブ</summary>
    [SerializeField] GameObject m_explosionPrefab = null;
    /// <summary>鍵を持ったカニカウント</summary>
    [SerializeField] KeyController m_keyController;
    [SerializeField] bool KeyKani;
    Animator m_anim = default;

    GameObject[] m_Kani = default;

    void Start()
    {
        m_anim = GetComponent<Animator>();
        m_Kani = GameObject.FindGameObjectsWithTag("Kani");
        
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Same")
        {
            Hp--;

            //エフェクトとなるプレハブが設定されていたら、それを生成する
            if (m_effectPrefab)
            {
                Instantiate(m_effectPrefab, this.transform.position, this.transform.rotation);
            }

            // 自分自身を破棄する処理
            if (Hp < 1) 
            {

                if (KeyKani==true) //KeyKaniにチェックが入っていた場合の処理
                {
                    Debug.Log("鍵を手に入れた");
                    m_keyController.KeyCount++;
                }

                if (m_explosionPrefab) // 爆発エフェクトを生成する
                {
                    Instantiate(m_explosionPrefab, this.transform.position, m_explosionPrefab.transform.rotation);
                }

                Destroy(this.gameObject);       // そして自分も破棄する
            }
        }
    }
    //Easyモード.Keyとなるカニ(敵)以外を消す。
    public void DisableAllKani()
    {
        m_Kani.ToList().ForEach(b => b.SetActive(false));
    }

}
