using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [Header("Move Info")]

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float runSpeed;
    [SerializeField] private float activeSpeed;
    private bool canDoubleJump;

    [Header("Ground Info")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private bool isGround;

    private bool isknockback;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
       
    }

    // Update is called once per frame
    void Update()

    {
        isGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);


        var xInput = Input.GetAxisRaw("Horizontal");

        activeSpeed = moveSpeed;

        if (Input.GetKey(KeyCode.LeftControl))
             activeSpeed = runSpeed;


        if (!isknockback)
        {

            rb.velocity = new Vector2(xInput * activeSpeed, rb.velocity.y);

            if(Input.GetButtonDown("Jump"))
            {

                if (isGround)
                {
                    Jump();
                    canDoubleJump = true;
                    anim.SetBool("isDoubleJumping", false);
                }
                else
                {

                    if (canDoubleJump)
                    {
                        Jump();
                        canDoubleJump = false;
                        anim.SetBool("isDoubleJumping", true);

                    }



                }
            }
            //Configurando dire��es
            if (rb.velocity.x > 0)
                transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
            if (rb.velocity.x < 0)
                transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);

            //chamando anima��es
            anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
            anim.SetBool("isGrounded", isGround);
            anim.SetFloat("ySpeed", rb.velocity.y);



        }

    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

    }
    public void Knockback()
    {
        isknockback = true;

        Vector2 knockbackDir = Vector2.zero;
        float knockbackJump = jumpForce * .5f; 

        if (rb.velocity.x > 0)
        {
            knockbackDir = new Vector2(rb.velocity.x * -.5f, knockbackJump); 
        
        }

        if(rb.velocity.x < 0)
        {
            knockbackDir = new Vector2(rb.velocity.x * -.5f, knockbackJump);
        }

        rb.velocity = knockbackDir;
        anim.SetTrigger("isknockback");

        StartCoroutine(EndKnockback());


    }

    IEnumerator EndKnockback()
    {
        yield return new WaitForSeconds(.2f);
        isknockback = false;
    }
}
