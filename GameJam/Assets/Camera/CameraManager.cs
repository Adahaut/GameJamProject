using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera mainCamera;
    

    private Vector3 offset = new Vector3 (0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    public float shakeLenght;
    public float shakeForce;


    float shakeAmount = 0f;


    [SerializeField] private Transform target;

    private void Awake()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    //Camera smooth follow
    void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        //Test camera shake
        if(Input.GetKeyDown(KeyCode.T))
        {
            Shake(shakeForce, shakeLenght);
        }
    }

    public void Shake(float amt,float lenght)
    {
        shakeAmount = amt;
        InvokeRepeating("DoShake", 0f, 0.01f);
        Invoke("StopShake", lenght);

    }

    private void DoShake()
    {

        if (shakeAmount > 0)
        {
            Vector3 camPos = mainCamera.transform.position;
            
            float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
            float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
            camPos.x = offsetX;
            camPos.y = offsetY;

            mainCamera.transform.localPosition = camPos;
        }
    }

    private void StopShake()
    {
        CancelInvoke("DoShake");
        mainCamera.transform.localPosition = Vector3.zero; 
    }
}
