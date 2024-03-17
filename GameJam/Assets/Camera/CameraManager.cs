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
    public bool followPlayer = true;
    public float targetMoveSpeed;
    public float targetMaxDistance;

    float shakeAmount = 0f;
    


    [SerializeField] private Transform playerTarget;
    [SerializeField] private Transform objectTarget;

    private void Awake()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    void Update()
    {
        if (followPlayer)
        {
            //Camera smooth follow
            Vector3 targetPosition = playerTarget.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
        else
        {
            Vector3 targetPosition = objectTarget.position + offset;
            Vector3 dir = Vector3.ClampMagnitude(targetPosition - transform.position, targetMaxDistance);
            //Vector3 dir = (targetPosition - transform.position).normalized * targetMaxDistance;
            //transform.position = Vector3.Slerp(transform.position, dir, Time.deltaTime * targetMoveSpeed);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * targetMoveSpeed * dir.magnitude);
        }


        //Test camera shake
        /*if (Input.GetKeyDown(KeyCode.T))
        {
            Shake(shakeForce, shakeLenght);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            followPlayer = !followPlayer;
        }*/
    }

    public void FollowTarget(Transform target, float time)
    {
        objectTarget = target;
        followPlayer = false;
    }

    public void EndFollow()
    {
        followPlayer = true;
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
