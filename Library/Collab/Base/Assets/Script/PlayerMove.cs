using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;

    private float movementSpeed;

    [SerializeField] private float runSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float buildUpSpeed;
    [SerializeField] private KeyCode runKey;

    [SerializeField] private float slopeForce;
    [SerializeField] private float slopeForceRayLength;

    private CharacterController charController;
    private bool isJump;

    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpmultiplier;
    [SerializeField] private KeyCode jumpKey;

    // Stamina
    [SerializeField] private Slider staminaBar;
    private float stamina;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        stamina = staminaBar.maxValue;
    }


    void Update()
    {
        PlayerMovement();
        staminaBar.value = stamina;
    }

    private void PlayerMovement()
    {
        float horizInput = Input.GetAxis(horizontalInputName);
        float vertInput = Input.GetAxis(verticalInputName);

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(Vector3.ClampMagnitude(forwardMovement + rightMovement, 1.0f) * movementSpeed);

        if ((vertInput != 0 || horizInput != 0) && OnSlope())
            charController.Move(Vector3.down * charController.height / 2 * slopeForce * Time.deltaTime);

        SetMovementSpeed();
        JumpInput();
    }

    private void SetMovementSpeed()
    {
        if (Input.GetKey(runKey))
        {
            if (stamina >= staminaBar.minValue)
            {
                stamina -= 0.3f;
                movementSpeed = Mathf.Lerp(movementSpeed, runSpeed, buildUpSpeed * Time.deltaTime);
            }
            else
                movementSpeed = Mathf.Lerp(movementSpeed, walkSpeed, buildUpSpeed * Time.deltaTime);
        }
        else
        {
            if(stamina <= staminaBar.maxValue) stamina += 0.1f;
            movementSpeed = Mathf.Lerp(movementSpeed, walkSpeed, buildUpSpeed * Time.deltaTime);
        }
    }

    private bool OnSlope()
    {
        if (isJump)
            return false;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, charController.height / 2 * slopeForceRayLength))
            if (hit.normal != Vector3.up)
                return true;

        return false;
    }

    private void JumpInput()
    {
        if (Input.GetKeyDown(jumpKey) && !isJump)
        {
            isJump = true;
            StartCoroutine(JumpEvent());
        }
    }

    private IEnumerator JumpEvent()
    {
        charController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;

        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpmultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        charController.slopeLimit = 45.0f;
        isJump = false;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Game Over");
        }
    }


} // CLASS
