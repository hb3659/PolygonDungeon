using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private PlayerInput input;
    [SerializeField]
    private CharacterController controller;
    [SerializeField]
    private Transform cam;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Transform groundCheck;

    private float moveSpeed = 3f;
    private float jumpHeight = 2f;
    private float gravity = -9.81f;
    private float groundDistance = 0.4f;

    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    private bool isGrounded = false;

    // 이동방향
    private Vector3 direction;
    private Vector3 gravityDir;

    [SerializeField]
    private LayerMask groundLayer;

    void FixedUpdate()
    {
        // 중력 적용
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        if (isGrounded && gravityDir.y < 0f)
            gravityDir.y = -2f;

        gravityDir.y += gravity * Time.deltaTime;
        controller.Move(gravityDir * Time.deltaTime);

        Move();
        Jump();
    }

    void Move()
    {
        // 페이드가 끝나면 움직임
        if (!FadeMng.Instance.IsFade)
        {
            direction = new Vector3(input.moveHorizontal, 0f, input.moveVertical).normalized;
            animator.SetBool("normalWalk", false);
            animator.SetBool("Defend", false);

            if (input.defense)
            {
                animator.SetBool("Defend", true);
            }
            else
            {
                if (direction.magnitude >= 0.1f)
                {
                    float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                    transform.rotation = Quaternion.Euler(0f, angle, 0f);

                    Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                    controller.Move(moveDir.normalized * moveSpeed * Time.deltaTime);

                    animator.SetBool("normalWalk", true);
                }
            }
        }
    }

    void Jump()
    {
        if (input.jump && isGrounded)
        {
            gravityDir.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetTrigger("Jump");
        }
    }
}
