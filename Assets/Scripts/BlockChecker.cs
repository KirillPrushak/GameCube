using UnityEngine;

public static class BlockChecker
{
    private const float VectorLenght = 0.51f;
    
    public static bool CheckIsGrounded(Vector3 position)
    {
        return Physics.Raycast(position, Vector3.down, VectorLenght);
    }

    public static bool HasBlocknInDerection (Vector3 position ,Vector3 direction)
    {
        var forwardDownDirection = direction * 1.0f;
        forwardDownDirection.y = -0.5f;
        var len = forwardDownDirection.magnitude;
        return Physics.Raycast(position, forwardDownDirection,len);
    }
    
    public static void SnapPositionToInteger(Transform transform)
    {
        var pos = transform.position;
        pos.x = Mathf.Round(pos.x);
        pos.z = Mathf.Round(pos.z);
        transform.position = pos;
    }
}