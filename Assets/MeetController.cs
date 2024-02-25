using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeetController : MonoBehaviour
{
    //アニメーションするためのコンポーネントを入れる
    //Animator myAnimator;

    //移動させるコンポーネントを入れる
    Rigidbody2D myRigidbody;

    //移動量
    private float velocity = 4.0f;

    //ジャンプ量
    private float jumppower = 24.0f;

    //地面に接触
    private bool isGround = false;

    //HP追加
    private int HP = 5;

   

    // Start is called before the first frame update
    void Start()
    {
        // アニメータのコンポーネントを取得する

        //this.myAnimator = GetComponent<Animator>();

        // Rigidbody2Dのコンポーネントを取得する
        this.myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //移動
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //左へ向く
            this.transform.localScale = new Vector2(-1.0f, 1.0f);

            //ジャンプ
            if (Input.GetKey(KeyCode.Space) && isGround)
            {
                //横移動＋ジャンプ
                this.myRigidbody.velocity = new Vector2(-velocity, jumppower);
            }
            else
            {
                //横移動
                this.myRigidbody.velocity = new Vector2(-velocity, this.myRigidbody.velocity.y);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            //右へ向く
            this.transform.localScale = new Vector2(1.0f, 1.0f);

            //ジャンプ
            if (Input.GetKey(KeyCode.Space) && isGround)
            {
                //横移動＋ジャンプ
                this.myRigidbody.velocity = new Vector2(velocity, jumppower);
            }
            else
            {
                //横移動
                this.myRigidbody.velocity = new Vector2(velocity, this.myRigidbody.velocity.y);
            }
        }
        else
        {
            //ジャンプ
            if (Input.GetKey(KeyCode.Space) && isGround)
            {
                //垂直ジャンプ
                this.myRigidbody.velocity = new Vector2(0.0f, jumppower);
            }
        }
    }

    //衝突（トリガー）
    void OnTriggerEnter2D(Collider2D other)
    {
        //地面 ※床が多いので床は全て Untaggedで実装する。
        if (other.gameObject.tag == "Untagged")
        {
            isGround = true;
        }

        //敵の攻撃
        if (other.gameObject.tag == "MonsterTag")
        {
            Debug.Log("ダメージ");
            HP--;
            //ノックバック
            myRigidbody.AddForce(new Vector2(-10f, 0), ForceMode2D.Impulse);

        }
    }

    //衝突（トリガー）※補強
    void OnTriggerStay2D(Collider2D other)
    {
        //地面 ※床が多いので床は全て Untaggedで実装する。
        if (other.gameObject.tag == "Untagged")
        {
            isGround = true;
        }
    }

    //衝突（トリガー）離れた
    void OnTriggerExit2D(Collider2D other)
    {
        //地面 ※床が多いので床は全て Untaggedで実装する。
        if (other.gameObject.tag == "Untagged")
        {
            isGround = false;
        }
    }
}














