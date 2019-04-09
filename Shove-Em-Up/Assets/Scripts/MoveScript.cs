﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 toMove;
    private bool onGround = true;
    private float gravity = 9;
    private float speed = 10;
    private float verticalSpeed = 0;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (characterController == null)
            characterController = gameObject.AddComponent<CharacterController>();
        toMove = Vector3.zero;
    }

    private void Update()
    {
        ResetVectorToMove();
        CheckGravity();
    }

    private void LateUpdate()
    {
        MoveCharacer(Time.deltaTime);
    }

    public void SetSpeed(float _speed)
    {
        speed = _speed;
    }

    public void SetGravity(float _gravity)
    {
        gravity = _gravity;
    }

    private void ResetVectorToMove()
    {
        toMove = Vector3.zero;
    }

    private void CheckGravity()
    {
        if (!onGround)
            verticalSpeed -= gravity;
        else
            verticalSpeed = 0;
    }

    public void AddVectorToMove(Vector3 _toMove)
    {
        toMove += _toMove;
    }

    private void MoveCharacer(float _time)
    {
        toMove.y += verticalSpeed * _time;
        CollisionFlags collisionFlags = characterController.Move(toMove);

        if ((collisionFlags & CollisionFlags.Below) != 0)
        {
            onGround = true;
        }
        else
            onGround = false;
    }
}
