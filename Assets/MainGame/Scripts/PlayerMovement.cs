using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float normalSpeed = 5f; // ความเร็วในการเดินปกติ
    [SerializeField] float sneakSpeed = 2f;  // ความเร็วในการเดินเมื่อหมอบ
    private Rigidbody rb;
    [Header("Sound")]
    [SerializeField] AudioSource walk;

    private bool isSneaking = false;
    private bool isWalking = false;
    private Transform cameraTransform;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        cameraTransform = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked; // ล็อกตำแหน่งเมาส์ที่ศูนย์กลาง
        Cursor.visible = false; // ซ่อนเมาส์
        
    }

    private void Update()
    {
        // ตรวจสอบการกดปุ่ม CTRL
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isSneaking = true;
            
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isSneaking = false;
            
        }
        isWalking = Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f;

        // Play or stop the walk sound based on whether the player is walking
        if (isWalking && !walk.isPlaying)
        {
            walk.Play();
        }
        else if (!isWalking && walk.isPlaying)
        {
            walk.Stop();
        }
        
        
        cameraTransform = Camera.main.transform;
        
    }

    private void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // หมุนกล้องตามการเคลื่อนที่ของเมาส์
        /*Vector3 cameraRotation = cameraTransform.localEulerAngles;
        cameraRotation.x -= mouseY;
        cameraTransform.localEulerAngles = cameraRotation;*/

        // หมุนตัวละครตามการเคลื่อนที่ของเมาส์
        Vector3 playerRotation = transform.localEulerAngles;
        playerRotation.y += mouseX;
        transform.localEulerAngles = playerRotation;

        // คำนวณทิศทางการเดินจากการหมุนกล้อง
        Vector3 movementDirection = cameraTransform.forward;
        movementDirection.y = 0f; // ไม่ต้องคำนวณทิศทางในแนวตั้ง
        movementDirection.Normalize();

        // รับค่า Input เพื่อเคลื่อนที่
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // เลือกความเร็วตามการหมอบหรือไม่
        float speed = isSneaking ? sneakSpeed : normalSpeed;

        Vector3 movement = (horizontalInput * cameraTransform.right + verticalInput * movementDirection).normalized * speed;

        // ทำการเคลื่อนที่
        Vector3 finalMovement = new Vector3(movement.x, rb.velocity.y, movement.z);
        rb.velocity = finalMovement;

        // ตรวจสอบว่าตัวละครอยู่บนพื้นหรือไม่
        /*if (isGrounded())
        {
            // ใช้แรงโน้มถ่วงในทิศทางลงเพื่อป้องกันการลอยขึ้น
            rb.AddForce(Physics.gravity * rb.mass);
        }*/
        if (Physics.Raycast(transform.position, Vector3.down, 0.1f))
        {
            // ปรับความเร็วในแนวตั้งลงเมื่อตัวละครอยู่บนพื้น
            rb.velocity = new Vector3(rb.velocity.x, Mathf.Max(rb.velocity.y, 0), rb.velocity.z);
        }
    }
    private bool isGrounded()
    {
        // ตรวจสอบว่าตัวละครอยู่บนพื้นหรือไม่
        float rayLength = 0.1f; // ยาวของ Raycast
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, rayLength))
        {
            // ตรวจสอบว่าระยะห่างระหว่างตัวละครกับพื้นน้อยกว่าหรือเท่ากับ rayLength
            return hit.distance <= rayLength;
        }

        return false;
    }
    
    public void ChangeSpeed(float newSpeed)
    {
        normalSpeed = newSpeed;
    }
}
