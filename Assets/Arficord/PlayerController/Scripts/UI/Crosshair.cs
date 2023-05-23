using UnityEngine;

namespace Arf.UI.HUD
{
    public abstract class Crosshair : MonoBehaviour
    {
        public abstract void SetLook(string lookType, bool flag);
    }
}
