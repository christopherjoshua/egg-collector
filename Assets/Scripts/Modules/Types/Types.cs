using System;
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

    public struct OnCollectEggMessage
    {
        public bool Success;
        public OnCollectEggMessage(bool success)
        {
            Success = success;
        }
    }
    public struct OnCollectBombMessage
    {
        public bool Success;
        public OnCollectBombMessage(bool success)
        {
            Success = success;
        }
    }

    public interface IEggController
    {
        string EggObjectType { get; }
        bool IsActive { get; }
        float Speed { get; }
        void SetEggActive(bool isActive);
        void SetRandomizePosition();
        void SetEggSpeed(float speed);
    }

    public enum Direction
    {
        RIGHT,
        DOWN,
        LEFT,
        UP
    }
}
