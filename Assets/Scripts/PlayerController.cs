using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool IsMoving { get; private set; }

    public float walkSpeed;
    public float runSpeed;
    public float jumpForce;
    public float strafeDamp = 2;
    public float backwardsDamp = 3;
    public Transform headTransform;

    private Rigidbody rb;
    private float xInput, zInput;
    private float actaulSpeed;

    private void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        actaulSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        IsMoving = !Mathf.Approximately(xInput, 0) || !Mathf.Approximately(zInput, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void FixedUpdate()
    {
        Vector3 moveX = xInput / strafeDamp * headTransform.right;
        Vector3 moveZ = zInput / (zInput < 0 ? backwardsDamp : 1) * headTransform.forward;
        Vector3 move = moveX + moveZ;
        Vector3 next = actaulSpeed * move * Time.fixedDeltaTime;
        rb.MovePosition(transform.position + next);
    }
}
