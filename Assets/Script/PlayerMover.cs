using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{

    Animator anim;

    public float moveSpeed = 1.0f;

    float vSpeed;
    float hSpeed;

    bool isActing = false;

    //0 : 위, 1 : 오른쪽, 2 : 아래 , 3 : 왼
    int direction;
    Vector2 dirVec;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Action();
    }
    private void Move()
    {
        if (isActing)
            return;
        vSpeed = Input.GetAxisRaw("Vertical");
        hSpeed = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("vSpeed", vSpeed);
        anim.SetFloat("hSpeed", hSpeed);
        Vector2 moveVec = new Vector2(hSpeed, vSpeed);
        anim.SetBool("IsMove", moveVec.magnitude < 0.01f);

        if (Input.GetButtonDown("Vertical"))
        {
            if(vSpeed > 0)
            {
                //위
                direction = 0;
                dirVec = Vector2.up;
            }
            else
            {
                //아래
                direction = 2;
                dirVec = Vector2.down;
            }
        }

        if (Input.GetButtonDown("Horizontal"))
        {
            if(hSpeed > 0)
            {
                //오른쪽
                direction = 1;
                dirVec = Vector2.right;
            }
            else
            {
                //왼쪽
                direction = 3;
                dirVec = Vector2.left;
            }
        }
        anim.SetInteger("diraction", direction);


        transform.Translate(new Vector2(hSpeed, vSpeed) * moveSpeed * Time.deltaTime);
    }

    void Action()
    {
        if (Input.GetButton("Jump"))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dirVec, 2f, LayerMask.GetMask("Object" , "NPC"));
            Debug.DrawRay(transform.position, dirVec * 1.5f, new Color(0, 1, 0));
            if(null != hit.collider){
                IInteraction target = hit.collider.gameObject.GetComponent<IInteraction>();
                if(null != target)
                {
                    isActing = target.ReAction();
                }
                return;
            }
        }
    }

}
