using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    public float speed = 0.3f;
    public float limitDistanceFollow = 2.5f;
    public float sprintSpeed = 0.5f;

    private bool follow;
    private bool sprint;

    GameObject player;

    Vector2 movingDirection;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        MovingAI();
    }

    private void MovingAI()
    {
        var sprint = player.GetComponent<Player_Controller>().sprint;

        movingDirection = new Vector2(player.transform.position.x - gameObject.transform.position.x, player.transform.position.y - gameObject.transform.position.y);

        if (Vector2.Distance(player.transform.position, gameObject.transform.position) > limitDistanceFollow)
        {
            follow = true;
        }
        else
        {
            follow = false;
        }
            
        if(follow)
            transform.Translate(movingDirection * speed * Time.deltaTime);


        if (sprint)
        {
            gameObject.transform.Translate(movingDirection * Time.deltaTime * sprintSpeed);
        }

    }
}
