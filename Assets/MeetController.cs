using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MeetController : MonoBehaviour
{
    //アニメーションするためのコンポーネントを入れる
    Animator myAnimator;

    //移動させるコンポーネントを入れる
    Rigidbody2D myRigidbody;

    //移動量
    private float velocity = 4.0f;

    //ジャンプ量
    private float jumppower = 14.0f;

    //地面に接触
    private bool isGround = false;

    //HP追加
    private int HP = 5;

    //HpUI追加
    public GameObject HpUI;

    //GameOver判定
    private bool isGameOver = false;

    //GameObver またはＣＬＥＡＲ用
    public GameObject textUI;

   

    // Start is called before the first frame update
    void Start()
    {
        // アニメータのコンポーネントを取得する
        this.myAnimator = GetComponent<Animator>();

        // Rigidbody2Dのコンポーネントを取得する
        this.myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
     　//プレイ中
        if(isGameOver == false)
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
                    //走る
                    myAnimator.SetBool("Run", true);

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
                    //走る
                    myAnimator.SetBool("Run", true);
                    //横移動
                    this.myRigidbody.velocity = new Vector2(velocity, this.myRigidbody.velocity.y);
                }
            }
            else
            {   //停止
                myAnimator.SetBool("Run", false);
                //ジャンプ
                if (Input.GetKey(KeyCode.Space) && isGround)
                {
                    //垂直ジャンプ
                    this.myRigidbody.velocity = new Vector2(0.0f, jumppower);
                }
            }

            //Jump制御
            if (isGround)
            {
                myAnimator.SetInteger("Jump", 0);
            }
            else
            {
                if (myRigidbody.velocity.y > 0)
                {
                    myAnimator.SetInteger("Jump", 1);
                }
                else
                {
                    myAnimator.SetInteger("Jump", -1);
                }
            }
        }

        //落下GameOver
        if(transform.position.y < -6.0f)
        {
            isGameOver = true;
            textUI.GetComponent<Text>().text = "Game Over";
        }

        //ゲームオーバーした EnterキーはReturn
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                //シーンを読み込む
                SceneManager.LoadScene("SampleScene");

            }
          }


    }

    //衝突（トリガー）
    void OnTriggerEnter2D(Collider2D other)
    {
        //ゴール
        if (other.gameObject.tag == "GoalTag")
        {
            isGameOver = true;
            textUI.GetComponent<Text>().text = "Clear";

            //停止
            myAnimator.SetBool("Run", false);
        }

        //地面 ※床が多いので床は全て Untaggedで実装する。
        if (other.gameObject.tag == "Untagged")
        {
            isGround = true;
        }

        //敵の攻撃
        if (other.gameObject.tag == "MonsterTag")
        {
            Debug.Log("ダメージ");

            //Damageのアニメ―ション
            myAnimator.SetTrigger("Damage");

            HP--;

            float scale = HP / 5.0f;

            if(scale < 0)
            {
                scale = 0;
            }

            HpUI.GetComponent<RectTransform>().localScale = new Vector3(scale, 1, 1);

            //死亡
            if(HP <= 0)
            {
                myAnimator.SetBool("Death", true);
                isGameOver = true;
                textUI.GetComponent<Text>().text = "Game Over";
            }
            //衝突した方向
            if(other.transform.position.x > transform.position.x)
            {
                //ノックバック左方向
                myRigidbody.AddForce(new Vector2(-10f, 0), ForceMode2D.Impulse);
            }
            else
            {
                //ノックバック右方向
                myRigidbody.AddForce(new Vector2(10f, 0), ForceMode2D.Impulse);
            }

           

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














