using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoxScript : MonoBehaviour
{
    private float min_x = -3.1f, max_x = 3.1f;

    private bool canMove;
    private float move_Speed = 2f;

    private Rigidbody2D myBody;
    //private SpringJoint2D newmyBody;

    private bool gameOver;
    private bool ignoreCollision;
    private bool ignoreTrigger;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myBody.gravityScale = 0f;//left-right moving should be without falling down
        //newmyBody = GetComponent<SpringJoint2D>();

    }

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;

        if(Random.Range(0,2)>0)
        {
            move_Speed *= -1f;
        }

        GameplayController.instance.currentBox = this;//??????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????
    }

    // Update is called once per frame
    void Update()
    {
        MoveBox();
    }

    void MoveBox()
    {
        if(canMove)
        {
            Vector3 temp = transform.position;
            temp.x += move_Speed * Time.deltaTime;

            if(temp.x > max_x)
            {
                move_Speed *= -1f;
            }
            else if (temp.x < min_x)
            {
                move_Speed *= -1f;
            }

            transform.position = temp;
        }
    }

    public void DropBox()
    {
        canMove = false;
        myBody.gravityScale = 3;
    }

    public void Landed()
    {
        if (gameOver) return;

        ignoreCollision = true;
        ignoreTrigger = true;

        GameplayController.instance.SpawnNewBox();
        GameplayController.instance.MoveCamera();
    }

    void RestartGame()
    {
        GameplayController.instance.RestartGame();
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (ignoreCollision) return;

        if (target.gameObject.tag == "Platform")
        {
            Invoke("Landed", 2f);
            ignoreCollision = true;
        }

        if (target.gameObject.tag == "Box")
        {
            Invoke("Landed", 2f);
            ignoreCollision = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (ignoreTrigger) return;

        if (target.tag == "GameOver")
        {
            CancelInvoke("Landed");
            gameOver = true;
            ignoreTrigger = true;

            Invoke("RestartGame", 2f);

        }
    }


}
