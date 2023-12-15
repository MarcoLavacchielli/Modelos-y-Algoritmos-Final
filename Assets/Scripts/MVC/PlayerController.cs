using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerModel playerModel;
    private PlayerView playerView;

    private int jumpsRemaining;

    private void Start()
    {
        playerModel = GetComponent<PlayerModel>();
        playerView = GetComponent<PlayerView>();
        PlayerLifeMemento initialMemento = playerModel.CreateMemento();
        playerModel.RestoreFromMemento(initialMemento);
        jumpsRemaining = playerModel.maxJumps;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        HandleMovement(moveDirection);
        HandleJump();

        // Simulaci�n de da�o al jugador durante el juego
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerModel.TakeDamage(10);
        }

        // Simulaci�n de recuperaci�n de vida (por ejemplo, al presionar una tecla)
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Crear un nuevo memento antes de realizar la recuperaci�n de vida
            PlayerLifeMemento recoveryMemento = playerModel.CreateMemento();

            // Simular recuperaci�n de vida (esto puede ser un valor espec�fico o basado en alg�n c�lculo)
            playerModel.RecoverLife(15);

            // Puedes guardar el memento despu�s de realizar la recuperaci�n de vida si quieres soportar deshacer (undo)
            // En este ejemplo, no lo estamos utilizando, pero podr�a ser �til en ciertos contextos.
        }
    }

    private void HandleMovement(Vector3 moveDirection)
    {
        if (moveDirection != Vector3.zero)
        {
            float rotationSpeed = 15f;
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            Quaternion newRotation = Quaternion.Slerp(playerModel.rb.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            playerModel.rb.MoveRotation(newRotation);

            playerView.UpdateMovement(moveDirection);
        }
        else
        {
            playerView.UpdateMovement(Vector3.zero);
        }

        playerModel.Move(moveDirection);
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpsRemaining > 0)
        {
            playerModel.Jump();
            jumpsRemaining--;
            playerView.UpdateJump(true);
        }
        else
        {
            playerView.UpdateJump(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            jumpsRemaining = playerModel.maxJumps;
        }
    }
}