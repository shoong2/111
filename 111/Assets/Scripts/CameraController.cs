using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float smoothSpeed = 0.125f; // ī�޶� �̵� �������� ���� �ӵ�
    public Transform target; // ī�޶� ���� ������Ʈ�� Transform ������Ʈ
    public GameObject player;
    public Player ground;

    public float cameraRange;
    private void LateUpdate()
    {
        if(!ground.isGround && transform.position.y>=-0.2f) //(player.GetComponent<Rigidbody2D>().velocity == Vector2.zero || player.transform.position.y>cameraRange)
        {
            Vector3 desiredPosition = new Vector3(transform.position.x, target.position.y, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}
