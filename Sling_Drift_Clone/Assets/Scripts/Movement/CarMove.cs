using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float speed;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = _player.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveCar();
    }


    void MoveCar()
    {
        float moveY = speed * Time.deltaTime;

        Vector2 movement = transform.up * moveY;
        rb.MovePosition(rb.position + movement);
    }
}