using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]

public class FollowCamera : MonoBehaviour
{
    // 追従対象
    public GameObject target; 

    // カメラの初期位置
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = Camera.main.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = target.transform.position;

        if(target.transform.position.x < 0)
        {
            cameraPos.x = 0; 
        }

        if(target.transform.position.x > 420)
        {
            cameraPos.x = 420; 
        }

        if(target.transform.position.y < 1)
        {
            cameraPos.y = 1;
        }

        cameraPos.z = -10;
        Camera.main.gameObject.transform.position = cameraPos;
    }
}
