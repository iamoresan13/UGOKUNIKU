using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SabController : MonoBehaviour
{   
    //�A�j���[�V�������邽�߂̃R���|�[�l���g������
    Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        // �A�j���[�^�̃R���|�[�l���g���擾����
        this.myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //�Փˁi�g���K�[�j
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //����グ��A�j���[�V����
            myAnimator.SetBool("FaceUp", true);
        }
    }

 }
