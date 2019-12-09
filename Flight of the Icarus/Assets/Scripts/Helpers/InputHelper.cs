using UnityEngine;

public static class InputHelper
{
    public static float GetSteering()
    {
        return Input.GetAxis("Horizontal");
    }

    public static float GetPanning()
    {
        return Input.GetAxis("Vertical");
    }

    public static bool IsSteering()
    {
        return GetSteering() != 0.0f;
    }

    public static bool IsPanning()
    {
        return GetPanning() != 0.0f;
    }
}
