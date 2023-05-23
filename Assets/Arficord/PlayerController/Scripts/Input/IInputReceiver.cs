using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public interface IInputReceiver
{
    void DoInput(InputContainer input);
}
