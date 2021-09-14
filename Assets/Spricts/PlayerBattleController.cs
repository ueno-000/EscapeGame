using UnityEngine;

/// <summary>
/// ガンマンのキャラクターを操作するコンポーネント
/// </summary>
public class PlayerBattleController : MonoBehaviour
{

    /// <summary>弾丸のプレハブ</summary>
    [SerializeField] GameObject m_bulletPrefab = default;
    /// <summary>銃口の位置を設定するオブジェクト</summary>
    [SerializeField] Transform m_muzzle = default;
    [SerializeField] HpController helth;
    [SerializeField] int Hp = 10;
 


    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            var go = Instantiate(m_bulletPrefab, this.m_muzzle.position, this.transform.rotation);
            //go.transform.position = m_muzzle.position;
            Hp--;
            helth.UpdateSlider(Hp);
            if (this.transform.localScale.x < 0)
            {
                go.transform.Rotate(Vector3.forward, 180f);
            }
        }
    }
}
