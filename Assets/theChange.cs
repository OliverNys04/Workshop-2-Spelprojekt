using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class theChange : MonoBehaviour
{
    public InputActionAsset workshop2; // Reference to Input Actions
    public Animator guyAnimation;      // Animator for animations

    private InputAction moveAction;

    void Start()
    {
        // Find the "Move" action in the InputActionAsset
        moveAction = workshop2.FindAction("Move");
        moveAction.Enable(); // Ensure the action is enabled
    }

    void Update()
    {
        // Check if there is movement input
        if (moveAction.ReadValue<Vector2>() != Vector2.zero)
        {
            guyAnimation.SetBool("running", true); // Start running animation
        }
        else
        {
            guyAnimation.SetBool("running", false); // Stop running animation
        }
    }
}