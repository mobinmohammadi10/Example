using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public bool isThisPlatformer;

    public float speed = 1f;
    public bool sprint = false;
    public float sprintSpeed = 3f;

    private float horizontal;
    private float vertical;
    private Vector2 moveDirection;
    private Animator player_Animator;
    private SpriteRenderer player_Sprite;

    // Start is called before the first frame update
    void Start()
    {
        player_Animator = GetComponent<Animator>();
        player_Sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        if (isThisPlatformer)
        {
            // do somthing here
        }
        UpdateAnimations();
    }

    private void Moving()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        moveDirection = new Vector2(horizontal, vertical);


        if (Input.GetKeyDown(KeyCode.LeftShift))
            sprint = true;

        if (Input.GetKeyUp(KeyCode.LeftShift))
            sprint = false;

        if (sprint)
        {
            gameObject.transform.Translate(moveDirection * Time.deltaTime * sprintSpeed);
        }
        gameObject.transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    private void UpdateAnimations()
    {

        if (Mathf.Abs(horizontal) > float.Epsilon || Mathf.Abs(vertical) > float.Epsilon)
        {
            player_Animator.SetBool("isWalking", true);
        }
        else
        {
            player_Animator.SetBool("isWalking", false);
        }

        if (horizontal < 0)
        {
            player_Sprite.flipX = true;
        }

        if (horizontal > 0)
        {
            player_Sprite.flipX = false;
        }
    }
}
