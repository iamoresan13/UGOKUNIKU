using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    //アニメーションするためのコンポーネントを入れる
    Animator myAnimator;

    //移動させるコンポーネントを入れる（追加）
    Rigidbody2D myRigidbody;

    //プレイヤー
    private GameObject Player;

    //タイマー
    private float timeCounter = 0f;

    //攻撃判定
    public GameObject AttackPrefab;
    
    //アニメーションイベント（攻撃）
    public void Attack()
    {
        //Debug.Log("攻撃");
        //生成
        GameObject attack = Instantiate(AttackPrefab, transform.position + new Vector3(-0.5f*Mathf.Sign(transform.localScale.x), 0, 0), Quaternion.identity);

        Destroy(attack, 0.1f);

    }

    //距離を求める（2D）
    float getLength2D(Vector2 current, Vector2 target)
    {
        return Mathf.Sqrt(((current.x - target.x) * (current.x - target.x)) + ((current.y - target.y) * (current.y - target.y)));
    }

    //方向を求める（2D） ※オイラー（-180～0～+180)
    float getEulerAngle2D(Vector2 current, Vector2 target)
    {
        Vector3 value = target - current;
        return Mathf.Atan2(value.x, value.y) * Mathf.Rad2Deg; //ラジアン→オイラー
    }

    //方向を求める（2D） ※ラジアン
    float getRadian2D(Vector2 current, Vector2 target)
    {
        Vector3 value = target - current;
        return Mathf.Atan2(value.x, value.y);
    }

    // Start is called before the first frame update
    void Start()
    {
        // アニメータのコンポーネントを取得する
        this.myAnimator = GetComponent<Animator>();
        // Rigidbody2Dのコンポーネントを取得する
        this.myRigidbody = GetComponent<Rigidbody2D>();

        //プレイヤーの取得
        Player = GameObject.Find("Meet");
    }

    // Update is called once per frame
    void Update()
    {
        //タイマー
        timeCounter += Time.deltaTime;

        //とりあえず1秒おきにチェック
        if (timeCounter > 1.0f)
        {
            //クリアー
            timeCounter = 0f;

            //プレイヤーが近い？
            if (getLength2D(transform.position, Player.transform.position) < 2.2f)
            {
                //プレイヤーの位置
                if(transform.position.x > Player.transform.position.x)
                {
                    //プレイヤーが左にいた　※画像のscaleサイズに合わせる事
                    this.transform.localScale = new Vector2(0.7f, 0.7f);
                }
                else
                {
                    //プレイヤーが右にいた
                    this.transform.localScale = new Vector2(-0.7f, 0.7f);
                }


                //アニメーション
                myAnimator.SetTrigger("Attack");
            }
        }
    }
}