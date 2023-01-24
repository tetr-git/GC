using UnityEngine;

public class FollowCameraScript : MonoBehaviour
{
    public GameObject player;
    public float OffSetX = 0.2f;
    public float OffsetY = -0.7f;
    private PlayerScript _player; 
    private Vector3 _offset;

    void Update()
    {   
        _offset = new Vector3(0, OffSetX, OffsetY);
        _player = player.GetComponent<PlayerScript>();
        Vector3 targetDirection = new Vector3(Mathf.Sin(_player.playerAngle), 0, Mathf.Cos(_player.playerAngle));
        Quaternion playerRotation = Quaternion.LookRotation(targetDirection);
        Vector3 offsetRotation = playerRotation * _offset;

        transform.rotation = playerRotation;
        transform.position = player.transform.position + offsetRotation;
        
    }
}
