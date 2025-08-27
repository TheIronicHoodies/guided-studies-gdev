using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private string currentAnimation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        ChangeAnimation("Stationary_Down");
    }

    // Update is called once per frame
    void Update()
    {
        CheckAnimation();
    }

    private void ChangeAnimation(string animation)
    {
        if (currentAnimation != animation)
        {
            animator.Play(animation);
            currentAnimation = animation;
        }
    }

    private void CheckAnimation()
    { 
        switch(PlayerController.direction)
        {
            case -2:
                if (!PlayerController.stationary && !ForcedMovementManager.stopAnimation)
                {
                    ChangeAnimation("Walk_Down");
                }
                else
                {
                    ChangeAnimation("Stationary_Down");
                }
                    break;
            case -1:
                if (!PlayerController.stationary && !ForcedMovementManager.stopAnimation)
                {
                    ChangeAnimation("Walk_Left");
                }
                else
                {
                    ChangeAnimation("Stationary_Left");
                }
                break;
            case 1:
                if (!PlayerController.stationary && !ForcedMovementManager.stopAnimation)
                {
                    ChangeAnimation("Walk_Right");
                }
                else
                {
                    ChangeAnimation("Stationary_Right");
                }
                break;
            case 2:
                if (!PlayerController.stationary && !ForcedMovementManager.stopAnimation)
                {
                    ChangeAnimation("Walk_Up");
                }
                else
                {
                    ChangeAnimation("Stationary_Up");
                }
                break;
        }
    }

}
