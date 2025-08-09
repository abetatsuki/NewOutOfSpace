using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Runtime
{
    /// <summary>
    /// 入力をバッファリングするクラス
    /// </summary>
    [RequireComponent (typeof (PlayerInput))]
    public class InputBuffer : MonoBehaviour
    {
        private const string MOVE_ACTION = "Move";
        private const string SPRINT_ACTION = "Sprint";
        private const string CARRY_ACTION = "Carry";
       
        public Vector2 Move { get;private set; }
        public bool Sprint { get; private set; }

        private InputAction _moveAction;
        private InputAction _sprintAction;
        private InputAction _carryAction;
        
    }
}

