using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float moveSpeed = 3.0f;

    Rigidbody2D rigid;
    Animator anim;

    float vSpeed;
    float hSpeed;

    Vector2 dirVec = Vector2.down;

    bool isActing = false;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        LookAt();
        Action();
    }

    private void Move()
    {
        if (isActing)
            return;

        // 이동처리
        vSpeed = Input.GetAxisRaw("Vertical");
        hSpeed = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("vSpeed", vSpeed);
        anim.SetFloat("hSpeed", hSpeed);
        Vector2 moveVec = new Vector2(hSpeed, vSpeed);
        anim.SetBool("isMove", moveVec.sqrMagnitude > 0.01f);

        rigid.velocity = new Vector2(hSpeed, vSpeed) * moveSpeed;
    }

    private void LookAt()
    {
        // 마지막으로 보고 있었던 방향 구하기
        if (vSpeed > 0)
        {
            dirVec = Vector2.up;
        }
        else if (vSpeed < 0)
        {
            dirVec = Vector2.down;
        }
        else if (hSpeed > 0)
        {
            dirVec = Vector2.right;
        }
        else if (hSpeed < 0)
        {
            dirVec = Vector2.left;
        }
        anim.SetFloat("dirV", dirVec.y);
        anim.SetFloat("dirH", dirVec.x);
    }

    void Action()
    {
        Debug.DrawRay(transform.position, dirVec * 1.5f, new Color(0, 1, 0));
        if (Input.GetButtonDown("Jump"))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dirVec, 1.5f, LayerMask.GetMask("Object", "NPC"));
            if (null != hit.collider)
            {
                IInteractable target = hit.collider.GetComponent<IInteractable>();
                if (null != target)
                {
                    isActing = target.ReAction();
                    return;
                }
            }
        }
    }
}