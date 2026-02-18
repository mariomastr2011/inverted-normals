using UnityEngine;

public class Misc
{
    public static Vector3 SnapPosition(Vector3 input, float factor = 1f)
    {
        if (factor <= 0f)
            throw new UnityException("factor argument must be above 0");

        float x = Mathf.Round(input.x / factor) * factor;
        float y = Mathf.Round(input.y / factor) * factor;
        float z = Mathf.Round(input.z / factor) * factor;

        return new Vector3(x,y,z);
    }
}
