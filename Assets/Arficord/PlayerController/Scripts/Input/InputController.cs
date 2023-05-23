using System.Collections;
using System.Collections.Generic;
using Arf.Player;
using UnityEngine;


namespace Arf.InputControll
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private PlayerController player;
        
        [SerializeField] private KeyCode shootButtonKeyCode = KeyCode.Mouse0;
        [SerializeField] private KeyCode aimButtonKeyCode = KeyCode.Mouse1;
        [SerializeField] private KeyCode jumpButtonKeyCode = KeyCode.Space;
        [SerializeField] private KeyCode runButtonKeyCode = KeyCode.LeftShift;
        [SerializeField] private KeyCode forwardButtonKeyCode = KeyCode.W;
        [SerializeField] private KeyCode backwardButtonKeyCode= KeyCode.S;
        [SerializeField] private KeyCode leftButtonKeyCode= KeyCode.A;
        [SerializeField] private KeyCode rightButtonKeyCode= KeyCode.D;
        [SerializeField] private string mouseXAxisName = "Mouse X";
        [SerializeField] private string mouseYAxisName = "Mouse Y";
        [SerializeField] private float mouseSensitivity = 500f;

        private IInputReceiver _inputReceiver;

        void Awake()
        {
            SwitchInputToPlayer();
        }

        void Update()
        {
            _inputReceiver.DoInput(GetInput());
        }

        public InputContainer GetInput()
        {
            Vector2 mouseAxis = GetMouseAxis();
            Vector2 moveAxis = GetMoveAxis();
            
            bool shootButtonPressed = Input.GetKeyDown(shootButtonKeyCode);
            bool aimButtonPressed = Input.GetKeyDown(aimButtonKeyCode);
            bool jumpButtonPressed = Input.GetKeyDown(jumpButtonKeyCode);
            bool runButtonHold = Input.GetKey(runButtonKeyCode);
            return new InputContainer(mouseAxis, moveAxis, shootButtonPressed, aimButtonPressed,
                jumpButtonPressed, runButtonHold);
        }

        public Vector2 GetMouseAxis()
        {
            return new Vector2(Input.GetAxis(mouseXAxisName), Input.GetAxis(mouseYAxisName)) *
                   mouseSensitivity; 
        }

        public Vector2 GetMoveAxis()
        {
            float xMovement = 0;
            float zMovement = 0;
            if (Input.GetKey(forwardButtonKeyCode))
            {
                zMovement += 1;
            }

            if (Input.GetKey(backwardButtonKeyCode))
            {
                zMovement -= 1;
            }

            if (Input.GetKey(rightButtonKeyCode))
            {
                xMovement += 1;
            }

            if (Input.GetKey(leftButtonKeyCode))
            {
                xMovement -= 1;
            }

            return new Vector2(xMovement, zMovement);
        }

        public void SwitchInputToPlayer()
        {
            _inputReceiver = player;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
