using UnityEngine;

/// <summary>
/// 爆発エフェクトを制御するコンポーネント
/// </summary>
public class EffectController : MonoBehaviour
{
    /// <summary>生存期間（秒）。この時間が経過したらエフェクトを破棄する</summary>
    [SerializeField] float m_lifetime = 0.7f;

    void Start()
    {

        Destroy(this.gameObject, m_lifetime);
    }
}
