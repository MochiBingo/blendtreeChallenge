using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody2D player;
    public float moveSpeed = 30f;
    private Vector2 moveVector = Vector2.zero;

    public void Start()
    {
        Actions.moveEvent += updateMoveVector;
    }
    public void Update()
    {
        moveChar(moveVector);
    }
    public void moveChar(Vector2 MoveVector)
    {
        player.MovePosition(player.position + moveVector * moveSpeed * Time.deltaTime);
    }
    private void updateMoveVector(Vector2 vector)
    {
        moveVector = vector;
    }
}
