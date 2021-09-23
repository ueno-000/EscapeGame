using UnityEngine;


public class PlayerBattleController : MonoBehaviour
{
    /// <summary>移動する時にかける力</summary>
    [SerializeField] float m_movePower = 3f;
    /// <summary>ジャンプ速度</summary>
    [SerializeField] float m_jumpPower = 5f;
    Rigidbody2D m_rb = default;
    /// <summary>接地フラグ</summary>
    bool m_isGrounded = false;
    Vector3 m_initialPosition = default;
    Animator m_anim = default;
    SpriteRenderer m_sprite = default;
    float m_h = 0;
    int JumpCount = 0;
    /// <summary>HP</summary>
    [SerializeField] HpController helth;
    [SerializeField] int Hp = 10;



    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();
        m_sprite = GetComponent<SpriteRenderer>();
        m_initialPosition = this.transform.position;
    }
    void  Update()
    {
        m_h = Input.GetAxis("Horizontal");
        Vector2 velocity = m_rb.velocity;

        // ジャンプ処理
        if (Input.GetButtonDown("Jump") && JumpCount < 2)
        {
            m_isGrounded = false;
            velocity.y = m_jumpPower;
            JumpCount++;
        }

        m_rb.velocity = velocity;

        // 画面外に落ちたら初期位置に戻す
        if (this.transform.position.y < -15)
        {
            this.transform.position = m_initialPosition;
        }

        //マウスクリックでanimation
        if (Input.GetButtonDown("Fire1"))
        {
            m_anim.SetTrigger("AttackTrigger");
        }

    }

    void FixedUpdate()
    {
        m_rb.AddForce(m_h * m_movePower * Vector2.right);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            JumpCount = 0;
          
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_isGrounded = true;
        if (collision.gameObject.tag == "Kani")
        {
            Hp--;
            m_anim.SetTrigger("DamageTrigger");
        }
        
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
            //m_anim.SetFloat("SpeedY", m_rb.velocity.y);
            m_anim.SetBool("IsGround", m_isGrounded);
        }
    }

}