using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeetController : MonoBehaviour
{
    //�A�j���[�V�������邽�߂̃R���|�[�l���g������
    //Animator myAnimator;

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

   

    // Start is called before the first frame update
    void Start()
    {
        // �A�j���[�^�̃R���|�[�l���g���擾����

        //this.myAnimator = GetComponent<Animator>();

        // Rigidbody2D�̃R���|�[�l���g���擾����
        this.myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
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
                //���ړ�
                this.myRigidbody.velocity = new Vector2(velocity, this.myRigidbody.velocity.y);
            }
        }
        else
        {
            //�W�����v
            if (Input.GetKey(KeyCode.Space) && isGround)
            {
                //�����W�����v
                this.myRigidbody.velocity = new Vector2(0.0f, jumppower);
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














