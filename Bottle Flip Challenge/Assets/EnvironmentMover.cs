using UnityEngine;
using System.Collections;

public class EnvironmentMover : MonoBehaviour
{
    public void MoveBy(float Offset)
    {
        Vector3 v = this.transform.position;
        this.transform.position = new Vector3(v.x, v.y, v.z + Offset);
    }
}
