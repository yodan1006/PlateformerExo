using UnityEngine;

public class FollowCamToPlayer : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    private void Update()
    {
        cam.transform.position = target.position + offset;
    }
}
