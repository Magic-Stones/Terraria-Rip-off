using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    public Transform cameraPosition;
    public Camera cameraSize;
    public Vector3 cameraOffset;

    public float increaseCameraSize = 3.0f, 
                 cameraSizeSpeed = 1.0f;

    private bool enemiesDetected; 
    private float defaultCameraSize;

    // Start is called before the first frame update
    void Start()
    {
        defaultCameraSize = cameraSize.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        cameraPosition.position = transform.position + cameraOffset;

        if (enemiesDetected)
        {
            CameraSizeIncrease(true);   
        }
        else
        {
            CameraSizeIncrease(false);
        }

    }

    public void CameraSizeIncrease(bool increaseSize)
    {
        if (increaseSize)
        {
            cameraSize.orthographicSize += cameraSizeSpeed * Time.deltaTime;

            if (cameraSize.orthographicSize >= increaseCameraSize)
            {
                cameraSize.orthographicSize = increaseCameraSize;
            }
        }
        else
        {
            cameraSize.orthographicSize -= cameraSizeSpeed * Time.deltaTime;

            if (cameraSize.orthographicSize <= defaultCameraSize)
            {
                cameraSize.orthographicSize = defaultCameraSize;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("EnemyTag"))
        {
            enemiesDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Contains("EnemyTag"))
        {
            enemiesDetected = false;
        }
    }
}
