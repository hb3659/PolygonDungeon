using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
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
    private float defendSpeed = 1.5f;
    private float jumpHeight = 2f;
    private float gravity = -9.81f;
    private float groundDistance = 0.4f;
    private float rotateSpeed = 7f;

    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    private bool isGrounded = false;

    // �̵�����
    private Vector3 direction;
    private Vector3 zoomDirection;
    private Vector3 gravityDir;

    [SerializeField]
    private LayerMask groundLayer;

    // ���� �� ������ �Ǽ� ��
    private float moveX;
    private float moveZ;

    void Start()
    {
        cam = Camera.main.transform;
    }

    void FixedUpdate()
    {
        // �߷� ����
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        if (isGrounded && gravityDir.y < 0f)
            gravityDir.y = -2f;

        gravityDir.y += gravity * Time.deltaTime;
        controller.Move(gravityDir * Time.deltaTime);

        if (GameManager.Instance.CurrentScene == "GameScene")
        {
            // ���� �������� �Է��� �޾� �����δ�.
            Move();
            Jump();

            Attack();
        }
    }

    void Move()
    {
        // ���̵尡 ������ ������
        if (!FadeMng.Instance.IsFade)
        {
            moveX = input.defendVertical;
            moveZ = input.defendHorizontal;

            direction = new Vector3(input.moveHorizontal, 0f, input.moveVertical).normalized;
            zoomDirection = new Vector3(input.defendHorizontal, 0f, input.defendVertical).normalized;

            animator.SetBool("normalWalk", false);
            animator.SetBool("Defend", false);
            animator.SetFloat("moveX", moveX);
            animator.SetFloat("moveY", moveZ);

            if (input.defense)
            {
                animator.SetBool("Defend", true);

                float targetAngle = cam.transform.eulerAngles.y;
                Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);

                if (zoomDirection.magnitude >= 0.1f)
                {
                    float camAngle = Mathf.Atan2(cam.position.x, cam.position.z) * Mathf.Rad2Deg;

                    transform.rotation = Quaternion.Euler(0, camAngle, 0);

                    controller.Move(zoomDirection.normalized * defendSpeed * Time.deltaTime);
                    animator.SetBool("normalWalk", true);
                }

                if (input.attack)
                    animator.SetTrigger("attackTrigger");
            }
            else
            {
                if (direction.magnitude >= 0.1f)
                {
                    // �Է� �������� ĳ���Ͱ� ȸ��
                    float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                    // �ڿ������� ȸ���� ���� ����
                    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                    transform.rotation = Quaternion.Euler(0f, angle, 0f);

                    // ī�޶� �ٶ󺸴� �������� ȸ��
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
            Debug.Log("JUMP!");
            gravityDir.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetTrigger("jumpTrigger");
        }
    }

    void Attack()
    {
        if (input.attack)
        {
            animator.SetTrigger("attackTrigger");
        }
    }
}
