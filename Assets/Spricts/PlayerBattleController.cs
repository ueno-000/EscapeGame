using UnityEngine;


public class PlayerBattleController : MonoBehaviour
{
    /// <summary>移動する時にかける力</summary>
    [SerializeField] float m_movePower = 3f;
    /// <summary>ジャンプ速度</summary>
    [SerializeField] float m_jumpSpeed = 5f;
    /// <summary>ジャンプ中にジャンプボタンを離した時の上昇速度減衰率</summary>
    [SerializeField] float m_gravityDrag = .8f;
    Rigidbody2D m_rb = default;
    /// <summary>接地フラグ</summary>
    bool m_isGrounded = false;
    Vector3 m_initialPosition = default;
    Animator m_anim = default;
    SpriteRenderer m_sprite = default;
    float m_h = 0;
    /// <summary>弾丸のプレハブ</summary>
    [SerializeField] GameObject m_bulletPrefab = default;
    /// <summary>銃口の位置を設定するオブジェクト</summary>
    [SerializeField] Transform m_muzzle = default;
    [SerializeField] HpController helth;
    [SerializeField] int Hp = 10;


    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();
        m_sprite = GetComponent<SpriteRenderer>();
        m_initialPosition = this.transform.position;
    }
    void Update()
    {
        m_h = Input.GetAxis("Horizontal");
        Vector2 velocity = m_rb.velocity;

        // ジャンプ処理
        if (Input.GetButtonDown("Jump") && m_isGrounded)
        {
            m_isGrounded = false;
            velocity.y = m_jumpSpeed;
        }
        else if (!Input.GetButton("Jump") && velocity.y > 0)
        {
            // 上昇中にジャンプボタンを離したら上昇を減速する
            velocity.y *= m_gravityDrag;
        }

        m_rb.velocity = velocity;

        // 画面外に落ちたら初期位置に戻す
        if (this.transform.position.y < -15)
        {
            this.transform.position = m_initialPosition;
        }
    }
    //if (Input.GetButtonDown("Fire1"))
    //{
    //    var go = Instantiate(m_bulletPrefab, this.m_muzzle.position, this.transform.rotation);
    //    //go.transform.position = m_muzzle.position;
    //    Hp--;
    //    helth.UpdateSlider(Hp);
    //    if (this.transform.localScale.x < 0)
    //    {
    //        go.transform.Rotate(Vector3.forward, 180f);
    //    }
    //}

    void FixedUpdate()
    {
        m_rb.AddForce(m_h * m_movePower * Vector2.right);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        m_isGrounded = false;
    }

    private void LateUpdate()
    {
        // キャラクターの左右の向きを制御する
        if (m_h != 0)
        {
            m_sprite.flipX = (m_h < 0);
        }

        // アニメーションを制御する
        if (m_anim)
        {
            m_anim.SetFloat("SpeedX", Mathf.Abs(m_rb.velocity.x));
            m_anim.SetFloat("SpeedY", m_rb.velocity.y);
            m_anim.SetBool("IsGrounded", m_isGrounded);
        }
    }
}