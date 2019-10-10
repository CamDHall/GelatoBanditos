using UnityEngine.InputSystem;
using UnityEngine;

public class MechMovement : MonoBehaviour
{
    public InputActionReference forwardActionReference;
    public InputActionReference backwardActionReference;
    public float movementForce;

    // Movement inputs
    Vector3 playerMovementInput;
    Vector3 lookInput;
    private int depthDirection;

    //GameObject mechModel;
    Rigidbody mechRB;

    //
    // Settings, move out later
    //
    public bool useMouse;
    public bool invert;

    private void OnEnable()
    {
        forwardActionReference.action.Enable();
        backwardActionReference.action.Enable();
    }

    private void OnDisable()
    {
        forwardActionReference.action.Disable();
        backwardActionReference.action.Disable();
    }

    void Start()
    {
        // 
        // Debug
        //
        InputSystem.DisableDevice(Pointer.current);


        //mechModel = GameObject.FindGameObjectWithTag("MechModel");
        mechRB    = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Collect Movement inputs
        depthDirection = forwardActionReference.action.phase == InputActionPhase.Started ? 1 : 0;
        depthDirection += backwardActionReference.action.phase == InputActionPhase.Started ? -1 : 0;
    }

    void FixedUpdate()
    {
        playerMovementInput.z = depthDirection;
        mechRB.AddForce(playerMovementInput * (movementForce * Time.deltaTime), ForceMode.Impulse);

        // Quat: z, y, z not x,y,z
        Debug.Log(lookInput.y);
        mechRB.MoveRotation(mechRB.rotation * Quaternion.Euler(lookInput.y, lookInput.x, 0));
        
        
        //transform.Rotate(new Vector3(lookInput.y, lookInput.x, 0));
    }

    public void Move(InputAction.CallbackContext context)
    {

        playerMovementInput = context.ReadValue<Vector2>();
    }

    public void Look(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }
}
