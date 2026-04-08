using UnityEngine;

public class CamMover : MonoBehaviour
{
    public Transform CamPos;
    private void Update()
    {
        transform.position = CamPos.position;
        transform.rotation = CamPos.rotation;
    }
}
