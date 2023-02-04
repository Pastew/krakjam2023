using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Player2DController : MonoBehaviour
{
    public int PlayerID;

    [SerializeField] private float raycastDistance = .1f;
    [SerializeField] private float raycastDistanceSide = .1f;
    [SerializeField] private Transform sideTransform_1;
    [SerializeField] private Transform sideTransform_2;
    [SerializeField] private float sideForce = .2f;
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float jumpPower = 5.0f;
    [SerializeField] private Rigidbody playerRigidbody;

    [SerializeField] private LayerMask _mask;

    [Space]
    [SerializeField] private AudioSource _jumpSFX;
    [SerializeField] private Vector2 _randomPitch = new Vector2(.6f, 1f);

    private void Start()
    {
        _jumpSFX.pitch = Random.Range(_randomPitch.x, _randomPitch.y);
    }

    private void Update()
    {
        MovePlayer();

        if (Input.GetButtonDown("Jump" + PlayerID) && IsGrounded())
        {
            Jump();

            if(!_jumpSFX.isPlaying)
            _jumpSFX.Play();
        }       
    }

    float horizontalInput;

    private void MovePlayer()
    {
        if (LeftRay())
            horizontalInput = sideForce;
        else if (RightRay())
            horizontalInput = -sideForce;

        if(!LeftRay() && !RightRay())
        horizontalInput = Input.GetAxisRaw("Horizontal"+ PlayerID);

        playerRigidbody.velocity = new Vector2(horizontalInput * playerSpeed, playerRigidbody.velocity.y);
    }

    private void Jump() => playerRigidbody.velocity = new Vector2(0, jumpPower);

    RaycastHit hit;

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, raycastDistance);
    }

    private bool LeftRay()
    {
        return (Physics.Raycast(sideTransform_1.position, Vector3.left, raycastDistanceSide) 
            || (Physics.Raycast(sideTransform_2.position, Vector3.left, raycastDistanceSide)));
    }

    private bool RightRay()
    {
        return (Physics.Raycast(sideTransform_1.position, Vector3.right, raycastDistanceSide)
             || (Physics.Raycast(sideTransform_2.position, Vector3.right, raycastDistanceSide)));
    }
}
