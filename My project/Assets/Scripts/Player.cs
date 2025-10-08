using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector2 movement, vectorAnim;
    private Animator anim;
    [SerializeField] private GameObject[] metalPepe;
    private string nameAnim, currentAnim;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        rb.velocity = movement * moveSpeed;
    }
    private void Update()
    {
        //if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        //{
        //    movement = new Vector2(movement.x, 1);
        //    vectorAnim = new Vector2(vectorAnim.x, 1);
        //    Metal(0);
        //    Anim("WalkUp");
        //}
        //else if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        //{
        //    movement = new Vector2(movement.x, -1);
        //    vectorAnim = new Vector2(movement.x, -1);
        //    Metal(1);
        //    Anim("WalkDown");
        //}
        //else
        //{
        //    movement = new Vector2(movement.x, 0);
        //    if (vectorAnim.y > 0 && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) Anim("IdleUp");
        //    if (vectorAnim.y < 0 && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) Anim("IdleDown");
        //}
        //if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        //{
        //    movement = new Vector2(-1, movement.y);
        //    vectorAnim = new Vector2(-1, movement.y);
        //    Metal(2);
        //    Anim("WalkLeft");
        //}
        //else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        //{
        //    movement = new Vector2(1, movement.y);
        //    vectorAnim = new Vector2(1, movement.y);
        //    Metal(3);
        //    Anim("WalkRight");
        //}
        //else
        //{
        //    movement = new Vector2(0, movement.y);
        //    if (vectorAnim.x > 0 && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W)) Anim("IdleRight");
        //    if (vectorAnim.x < 0 && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W)) Anim("IdleLeft");
        //}
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        // Если игрок двигается
        if (movement.magnitude > 0)
        {
            movement.Normalize(); // Нормируем вектор движения
            Move();
            vectorAnim = movement;
        }
        else
        {
            Idle();
        }
    }
    private void Move()
    {
        // Перемещаем игрока
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // Определяем направление для анимации
        if (movement.x > 0)
        {
            anim.Play("WalkRight");
            Metal(3);
        }
        else if (movement.x < 0)
        {
            anim.Play("WalkLeft");
            Metal(2);
        }
        else if (movement.y > 0)
        {
            anim.Play("WalkUp");
            Metal(0);
        }
        else if (movement.y < 0)
        {
            anim.Play("WalkDown");
            Metal(1);
        }
    }

    private void Idle()
    {
        // Устанавливаем Idle анимацию в зависимости от последнего направления
        if (vectorAnim.x > 0)
        {
            anim.Play("IdleRight");
        }
        else if (vectorAnim.x < 0)
        {
            anim.Play("IdleLeft");
        }
        else if (vectorAnim.y > 0)
        {
            anim.Play("IdleUp");
        }
        else if (vectorAnim.y < 0)
        {
            anim.Play("IdleDown");
        }
    }
    private void Anim(string name)
    {
        if (currentAnim != name)
        {
            anim.Play(name);
            currentAnim = name;
        }
    }
    void Metal(int metal)
    {
        for(int i = 0; i < 4; i++)
        {
            if(metal == i) metalPepe[i].SetActive(true);
            else metalPepe[i].SetActive(false);
        }
    }
}
