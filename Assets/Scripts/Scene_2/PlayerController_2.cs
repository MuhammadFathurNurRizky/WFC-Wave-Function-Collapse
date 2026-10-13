using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_2 : MonoBehaviour
{
    // Camera Rotation
    [SerializeField] float mouseSensitivity = 2f;
    private GameObject characterCamera;
    private Transform cameraTransform;

    // Ground Movement
    private CharacterController controller;
    private Vector3 playerVelocity;
    private float moveVertical;
    private float moveHorizontal;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float gravityForce = -9.8f;

    // Jumping
    [SerializeField] float jumpForce = 2f;
    [SerializeField] float descendMultiplier = 1f;
    private bool groundedPlayer;

    // Animation
    private Animator animator;
    private string currentAnimation = "";
    private int currentIdle = 0;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        characterCamera = GameObject.FindWithTag("MainCamera");
        cameraTransform = characterCamera.GetComponent<Transform>();

        // Lock Mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Animation
        animator = GetComponent<Animator>();
        StartCoroutine(ChangeIdle());
        IEnumerator ChangeIdle()
        {
            while (true)
            {
                yield return new WaitForSeconds(5);
                ++currentIdle;
                if (currentIdle >= 2)
                {
                    currentIdle = 0;
                }
            }
        }

    }

    void Update()
    {
        // Read Input
        moveHorizontal = Input.GetAxisRaw("Horizontal"); // A/D
        moveVertical = Input.GetAxisRaw("Vertical");     // W/S

        // Correct axis mapping: X = horizontal, Z = vertical
        Vector3 move = new Vector3(moveVertical, 0, moveHorizontal);

        // Normalize diagonal movement
        move = Vector3.ClampMagnitude(move, 1f);

        // Ground check
        groundedPlayer = controller.isGrounded;
        if (playerVelocity.y < -2f)
        {
            playerVelocity.y = -2f;
        }

        // Apply gravity
        playerVelocity.y += gravityForce * Time.deltaTime;

        // Jump
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y = Mathf.Sqrt(jumpForce * -2f * gravityForce);
        }

        // Final movement vector
        Vector3 finalMove = move * moveSpeed + Vector3.up * playerVelocity.y;
        controller.Move(finalMove * Time.deltaTime);

        // Animation
        CheckAnimation();
        if (groundedPlayer && Input.GetKeyDown(KeyCode.Mouse0))
        {
            ChangeAnimation("PunchLeft");
        }
        if (groundedPlayer && Input.GetKeyDown(KeyCode.Mouse1))
        {
            ChangeAnimation("BlockingLoop");
        }
        
    }

    private void CheckAnimation()
    {
        if (currentAnimation == "BlockingLoop" || currentAnimation == "Jump" || currentAnimation == "PunchLeft")
        {
            return;
        }

        if (moveVertical == 1)
        {
            ChangeAnimation("RunForward");
        }
        else if (moveVertical == -1)
        {
            ChangeAnimation("RunBackward");
        }
        else if (moveHorizontal == 1)
        {
            ChangeAnimation("StrafeRight");
        }
        else if (moveHorizontal == -1)
        {
            ChangeAnimation("StrafeLeft");
        }
        else
        {
            CheckIdle();
        }

        void CheckIdle()
        {
            switch (currentIdle)
            {
                case 0:
                    ChangeAnimation("Idle");
                    break;
                case 1:
                    ChangeAnimation("IdleCombat");
                    break;
            }
        }
    }

    // This function can ChangeAnimation to next animation.
    public void ChangeAnimation(string animation, float crossfade = 0.2f, float time = 0)
    {
        if (time > 0)
        {
            StartCoroutine(Wait());
        }
        else
        {
            Validate();
        }

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(time - crossfade);
            Validate();
        }

        void Validate()
        {
            if (currentAnimation != animation)
            {
                currentAnimation = animation;
                if (currentAnimation == "")
                {
                    CheckAnimation();
                }
                else
                {
                    animator.CrossFade(animation, crossfade);
                }
            }
        }
    }
}