using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Types
{
    public struct OnMovementInputMessage
    {
        public KeyCode MoveLeft;
        public KeyCode MoveRight;

        public OnMovementInputMessage(KeyCode moveLeft, KeyCode moveRight)
        {
            MoveLeft = moveLeft;
            MoveRight = moveRight;
        }
    }
    public struct OnTimerTimeoutMessage
    {
    }

    public struct OnGetObjectMessage
    {
        public string ObjectType;
        public OnGetObjectMessage(string objectType)
        {
            ObjectType = objectType;
        }
    }

    public enum Direction
    {
        RIGHT,
        DOWN,
        LEFT,
        UP
    }
}
