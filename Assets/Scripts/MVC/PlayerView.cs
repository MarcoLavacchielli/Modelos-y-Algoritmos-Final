using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Charview view;

    public void UpdateMovement(Vector3 moveDirection)
    {
        if (moveDirection.magnitude > 0.1f)
        {
            view.Isrunning(true);
        }
        else
        {
            view.Isrunning(false);
        }
    }

    public void UpdateJump(bool isJumping)
    {
        view.Isjumping(isJumping);
    }
}