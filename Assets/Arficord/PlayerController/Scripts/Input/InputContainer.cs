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
    
    public bool equip0ButtonPress;
    public bool equip1ButtonPress;
    public bool equip2ButtonPress;

    public InputContainer(Vector2 mouseAxis, Vector2 moveAxis, bool shootButtonPressed, bool aimButtonPressed, 
        bool jumpButtonPressed, bool runButtonHold, bool equip0ButtonPress, bool equip1ButtonPress, bool equip2ButtonPress)
    {
        this.mouseAxis = mouseAxis;
        this.moveAxis = moveAxis;

        this.shootButtonPressed = shootButtonPressed;
        this.aimButtonPressed = aimButtonPressed;
        
        this.jumpButtonPressed = jumpButtonPressed;
        this.runButtonHold = runButtonHold;

        this.equip0ButtonPress = equip0ButtonPress;
        this.equip1ButtonPress = equip1ButtonPress;
        this.equip2ButtonPress = equip2ButtonPress;
    }
}
