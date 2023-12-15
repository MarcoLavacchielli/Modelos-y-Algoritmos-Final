using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public Charview view;

    public void UpdateMovement(Vector3 moveDirection)
    {
        // Handle movement visualization here (animation, etc.)
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
        // Handle jump visualization here (animation, etc.)
        view.Isjumping(isJumping);
    }
}