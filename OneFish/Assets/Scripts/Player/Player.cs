using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float movSpeed;
    float speedX, speedY;
    public static bool canFish = false;
    public bool facingRight;
    Rigidbody2D rigidB;
    SpriteRenderer spriteR;
    Animator anime;
    
    void Start()
    {
        rigidB = GetComponent<Rigidbody2D>();
        spriteR = GetComponent<SpriteRenderer>();
        anime = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        Move();
        Flip();

    }
    
    void Move()
    {
        speedX = Input.GetAxisRaw("Horizontal");
        speedY = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(speedX, speedY);
        direction = direction.normalized;

        rigidB.velocity = direction * movSpeed;

        if (speedX != 0)
        {
            
            ResetLayer();
            anime.SetLayerWeight(2, 1);
        }

        if(speedY > 0 && speedX != 0)
        {
            ResetLayer();
            anime.SetLayerWeight(2, 1);
        }
        if(speedY > 0 && speedX == 0)
        {
            ResetLayer();
            anime.SetLayerWeight(0, 1);
        }
        else if(speedY < 0 && speedX == 0)
        {
            ResetLayer();
            anime.SetLayerWeight(1, 1);
        }

    }

    private void ResetLayer()
    {
        
        anime.SetLayerWeight(0, 0);
        anime.SetLayerWeight(1, 0);
        anime.SetLayerWeight(2, 0);
        

    }

    void Flip()
    {
        if (facingRight && speedX > 0 || !facingRight && speedX < 0)
        {
            facingRight = !facingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1;
            transform.localScale = ls;
        }
    }
    public void AllowFish(bool canFishInArea)
    {
        canFish = canFishInArea;
    }


        /*
        void FollowMouse()
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);


            Vector2 directionF = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
            transform.up = directionF;
        }



        void ApplyRotation()
        {
            rotationAngle = rotationAngle - (speedX * rotationSpeed);
            rigidB.MoveRotation(rotationAngle);
        }
        */


}




    
