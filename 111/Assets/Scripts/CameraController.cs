using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //public float smoothSpeed = 0.125f; // 카메라 이동 스무딩을 위한 속도
    //public Transform target; // 카메라가 따라갈 오브젝트의 Transform 컴포넌트
    //public GameObject player;
    //public Player ground;

    //public float cameraRange;
    //private void LateUpdate()
    //{
    //    if(!ground.isGround && transform.position.y>=-0.2f) //(player.GetComponent<Rigidbody2D>().velocity == Vector2.zero || player.transform.position.y>cameraRange)
    //    {
    //        Vector3 desiredPosition = new Vector3(transform.position.x, target.position.y, transform.position.z);
    //        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    //        transform.position = smoothedPosition;
    //    }
    //}
    private void Awake()
    {
        Camera cam = GetComponent<Camera>();
        Rect rt = cam.rect;
        float scale_height = ((float)Screen.width / Screen.height) / ((float)9 / 16);
        float scale_width = 1f / scale_height;

        if (scale_height < 1)
        {
            rt.height = scale_height;
            rt.y = (1f - scale_height) / 2f;
        }
        else
        {
            rt.width = scale_width;
            rt.x = (1f - scale_width) / 2f;
        }

        cam.rect = rt;
    }

    void OnPreCull() => GL.Clear(true, true, Color.black);
}
