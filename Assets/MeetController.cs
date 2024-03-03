using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeetController : MonoBehaviour
{
    //�A�j���[�V�������邽�߂̃R���|�[�l���g������
    Animator myAnimator;

    //�ړ�������R���|�[�l���g������
    Rigidbody2D myRigidbody;

    //�ړ���
    private float velocity = 4.0f;

    //�W�����v��
    private float jumppower = 24.0f;

    //�n�ʂɐڐG
    private bool isGround = false;

    //HP�ǉ�
    private int HP = 5;

    //HpUI�ǉ�
    public GameObject HpUI;

    //GameOver����
    private bool isGameOver = false;
   

    // Start is called before the first frame update
    void Start()
    {
        // �A�j���[�^�̃R���|�[�l���g���擾����
        this.myAnimator = GetComponent<Animator>();

        // Rigidbody2D�̃R���|�[�l���g���擾����
        this.myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
     �@//�v���C��
        if(isGameOver == false)
        {
            //�ړ�
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                //���֌���
                this.transform.localScale = new Vector2(-1.0f, 1.0f);

                //�W�����v
                if (Input.GetKey(KeyCode.Space) && isGround)
                {
                    //���ړ��{�W�����v
                    this.myRigidbody.velocity = new Vector2(-velocity, jumppower);
                }
                else
                {
                    //����
                    myAnimator.SetBool("Run", true);

                    //���ړ�
                    this.myRigidbody.velocity = new Vector2(-velocity, this.myRigidbody.velocity.y);
                }
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                //�E�֌���
                this.transform.localScale = new Vector2(1.0f, 1.0f);

                //�W�����v
                if (Input.GetKey(KeyCode.Space) && isGround)
                {
                    //���ړ��{�W�����v
                    this.myRigidbody.velocity = new Vector2(velocity, jumppower);
                }
                else
                {
                    //����
                    myAnimator.SetBool("Run", true);
                    //���ړ�
                    this.myRigidbody.velocity = new Vector2(velocity, this.myRigidbody.velocity.y);
                }
            }
            else
            {   //��~
                myAnimator.SetBool("Run", false);
                //�W�����v
                if (Input.GetKey(KeyCode.Space) && isGround)
                {
                    //�����W�����v
                    this.myRigidbody.velocity = new Vector2(0.0f, jumppower);
                }
            }

            //Jump����
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

       

    }

    //�Փˁi�g���K�[�j
    void OnTriggerEnter2D(Collider2D other)
    {
        //�n�� �����������̂ŏ��͑S�� Untagged�Ŏ�������B
        if (other.gameObject.tag == "Untagged")
        {
            isGround = true;
        }

        //�G�̍U��
        if (other.gameObject.tag == "MonsterTag")
        {
            Debug.Log("�_���[�W");
            HP--;

            float scale = HP / 5.0f;

            if(scale < 0)
            {
                scale = 0;
            }

            HpUI.GetComponent<RectTransform>().localScale = new Vector3(scale, 1, 1);

            //���S
            if(HP <= 0)
            {
                myAnimator.SetBool("Death", true);
                isGameOver = true;
            }

            //�m�b�N�o�b�N
            myRigidbody.AddForce(new Vector2(-10f, 0), ForceMode2D.Impulse);

        }
    }

    //�Փˁi�g���K�[�j���⋭
    void OnTriggerStay2D(Collider2D other)
    {
        //�n�� �����������̂ŏ��͑S�� Untagged�Ŏ�������B
        if (other.gameObject.tag == "Untagged")
        {
            isGround = true;
        }
    }

    //�Փˁi�g���K�[�j���ꂽ
    void OnTriggerExit2D(Collider2D other)
    {
        //�n�� �����������̂ŏ��͑S�� Untagged�Ŏ�������B
        if (other.gameObject.tag == "Untagged")
        {
            isGround = false;
        }
    }
}














