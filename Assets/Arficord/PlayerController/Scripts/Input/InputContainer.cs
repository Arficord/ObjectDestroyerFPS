using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct InputContainer
{
    public Vector2 mouseAxis;
    public Vector2 moveAxis;
    
    public bool shootButtonPressed;
    public bool aimButtonPressed;
    public bool jumpButtonPressed;
    public bool runButtonHold;
    public RaycastHit lookAt;
    
    public InputContainer(Vector2 mouseAxis, Vector2 moveAxis, bool shootButtonPressed, bool aimButtonPressed, bool jumpButtonPressed, bool runButtonHold, RaycastHit lookAt)
    {
        this.mouseAxis = mouseAxis;
        this.moveAxis = moveAxis;

        this.shootButtonPressed = shootButtonPressed;
        this.aimButtonPressed = aimButtonPressed;
        
        this.jumpButtonPressed = jumpButtonPressed;
        this.runButtonHold = runButtonHold;

        this.lookAt = lookAt;
    }
}
