using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private Vector3 targetPosition;
    [SerializeField] private float rotateSpeed = 5f;
    [SerializeField] private Animator unitAnimator;

    private void Awake()
    {
        targetPosition = transform.position;
    }
    private void Update()
    {
        //unitAnimator.SetBool("IsWalking", true);
        float stoppingDistance = 0.1f;
        if (Vector3.Distance(targetPosition, transform.position) > stoppingDistance)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            float moveSpeed = 4f;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
            unitAnimator.SetBool("IsWalking", true);

            //transform.forward = Vector3.Lerp(transform.forward ,moveDirection, Time.deltaTime * rotateSpeed);
            transform.forward = Vector3.MoveTowards(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);
        }
        else
        {
            unitAnimator.SetBool("IsWalking", false);
        }


    }
    public void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }
}
