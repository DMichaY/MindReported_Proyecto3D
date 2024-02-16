using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 1.15f;
    public float runSpeed = 4.0f;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;
    public float gravity = 150.0f;
    public float rotationThreshold = 0.1f;  // Umbral para la zona muerta

    public CharacterController characterController;
    private Animator characterAnimator;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private bool controlsActivated = false;
    private bool canMove = true;  // Declarar la variable canMove aqu�

    
    void Update()
    {
        if (!controlsActivated)
        {
            return; // Salir del m�todo si los controles no est�n activados
        }

        // Obtener las direcciones hacia adelante y hacia la derecha del personaje
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Verificar si el jugador est� corriendo
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        // Calcular la velocidad actual en los ejes X e Y
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;

        // Guardar la direcci�n del movimiento antes de aplicar la gravedad
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        // Aplicar la gravedad si el personaje no est� en el suelo
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Mover al personaje
        characterController.Move(moveDirection * Time.deltaTime);


        if (canMove)
        {
            // Obtener la entrada del mouse para la rotaci�n en el eje Y
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;

            // Limitar la rotaci�n en el eje Y
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

            // Aplicar la rotaci�n a la c�mara localmente
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

            // Rotar el personaje en el eje Y
            transform.Rotate(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

    }
}
