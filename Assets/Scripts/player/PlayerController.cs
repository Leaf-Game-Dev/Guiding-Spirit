using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Camera mainCam;
    [SerializeField] Animator animator;
    [SerializeField] LayerMask layerMask;
    [SerializeField] Transform FollowTransform;

    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float normalSpeed,maxSpeed,minSpeed;


    float VerticalInput, currentSpeed;
    float xMin = -45;
    float xMax = 45;
    public float distToGround = -.5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public Transform GetFollowTransform()
    {
        return FollowTransform;
    }
    private void Start()
    {
        currentSpeed = normalSpeed;
        Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = false;
    }

    private void Update()
    {

        currentSpeed = normalSpeed;

        VerticalInput = Input.GetAxis("Vertical");
        float HorizontalInput = Input.GetAxis("Horizontal") ;

        if (VerticalInput >= 0) animator.SetFloat("Speed", new Vector3(VerticalInput, HorizontalInput).magnitude);
        else
        {
            animator.SetFloat("Speed", -1);
            currentSpeed = minSpeed;
        }
        if (Input.GetKey(KeyCode.LeftShift) && currentSpeed != minSpeed)
        {
            if (rb.velocity.magnitude >= normalSpeed) animator.SetFloat("Speed", 2);
            currentSpeed = maxSpeed;
        }

        // rotate 
        transform.Rotate(0, rotationSpeed * Time.deltaTime* HorizontalInput, 0,Space.World);
        Vector3 currentRotation = transform.localRotation.eulerAngles;
        currentRotation.z = 0;
        currentRotation.x = ClampAngle(currentRotation.x, xMin, xMax);

        transform.rotation = Quaternion.Euler(currentRotation);
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;

            Cursor.visible = true;
        }
    }

    private void FixedUpdate()
    {
        /*if (VerticalInput == 0)
        {
            rb.velocity = Vector3.zero;
        }*/
        if( rb.velocity.magnitude < currentSpeed) rb.AddForce(transform.forward* VerticalInput * speed * Time.deltaTime, ForceMode.Impulse);

        

    }

    public void PlayFootSound()
    {
        SoundManager.PlaySound(SoundManager.Sound.FootStep, .1f);
    }

    public bool IsGrounded(){
        return Physics.Raycast(transform.position + new Vector3(0, distToGround + 0.1f, 0), -transform.up,0.1f,layerMask);
    }

    float ClampAngle(float angle, float from, float to)
    {
        // accepts e.g. -80, 80
        if (angle < 0f) angle = 360 + angle;
        if (angle > 180f) return Mathf.Max(angle, 360 + from);
        return Mathf.Min(angle, to);
    }
}
