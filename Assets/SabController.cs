using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SabController : MonoBehaviour
{   
    //アニメーションするためのコンポーネントを入れる
    Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        // アニメータのコンポーネントを取得する
        this.myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //衝突（トリガー）
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //顔を上げるアニメーション
            myAnimator.SetBool("FaceUp", true);
        }
    }

 }
