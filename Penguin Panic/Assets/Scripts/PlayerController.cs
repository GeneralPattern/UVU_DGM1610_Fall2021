using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Stats")]

    public float moveSpeed;             // movement speed in units per second

    public float jumpForce;             // force applied upwards

    public int curHp;

    public int maxHp;

    [Header("Mouse Look")]
    public float lookSensitivity;       // mouse look sensitivity

    public float maxLookx;              // highest we can look up

    public float minLookx;

    private float rotX;                 // Current x rotation for the camera


    private Camera camera;

    private Rigidbody rb;

    private Weapon weapon;

    public bool gamePaused2;


    void Awake()
    {
        //locks cursor
        Cursor.lockState = CursorLockMode.Locked;
        weapon = GetComponent<Weapon>();
    }


    void Start()
    {
        //Get Components
        camera = Camera.main;
        rb = GetComponent<Rigidbody>();

        GameUI.instance.UpdateScoreText(0);
        GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
    }


    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        //rb.velocity = new Vector3(x, rb.velocity.y, z); - Old Code

        Vector3 dir = transform.right * x + transform.forward * z;
        
        rb.velocity = dir;
        dir.y = rb.velocity.y;

    }


    void CamLook()
    {
        //enables moving camera with mouse
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;

        rotX = Mathf.Clamp(rotX, minLookx, maxLookx);
        camera.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y;
    }


    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if(Physics.Raycast(ray, 1.1f))
            rb.AddForce (Vector3.up * jumpForce, ForceMode.Impulse);
    
    }




    public void GiveAmmo(int amountToGive)
    {
        weapon.curAmmo = Mathf.Clamp(weapon.curAmmo + amountToGive, 0, weapon.maxAmmo);
        GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
    }

    void OnTriggerEnter(Collider other)
    {
        //Lose game if hit     
        if(other.CompareTag("Enemy"))
            ToggleToggleEnd();
    }

    public void ToggleToggleEnd()
    {
        gamePaused2 = !gamePaused2;
        Time.timeScale = gamePaused2 == true ? 0.0f : 1.0f;

        //Toggle lost screen
        GameUI.instance.TogglePauseMenu2(gamePaused2);
        Cursor.lockState = gamePaused2 == true ?  CursorLockMode.None : CursorLockMode.Locked;

    }

    void Update()
    {
        Move();
        CamLook();
        if(Input.GetButton("Fire1"))
            {
                if(weapon.CanShoot())
                    weapon.Shoot();
            }

        if(Input.GetButtonDown("Jump"))
            Jump();
        
        //Pauses Game
        if(GameManager.instance.gamePaused == true)
            return;
        
    }
}
