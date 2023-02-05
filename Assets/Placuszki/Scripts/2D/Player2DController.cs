using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using Mirror;

public class Player2DController : NetworkBehaviour
{
    public int PlayerID;

    [SerializeField] private Animator _animator;

    [SerializeField] private float raycastDistance = .1f;
    [SerializeField] private float raycastDistanceSide = .1f;
    [SerializeField] private float monkeyModelRotationSpeed = 6f;

    [SerializeField] private Transform _monkeObject;

    [SerializeField] private Transform DownRaycast_1;
    [SerializeField] private Transform DownRaycast_2;

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

    bool leftTurn = true;
    bool stopped = true;


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

            _animator.SetTrigger("j");

            if (!_jumpSFX.isPlaying)
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

        if (!LeftRay() && !RightRay())
        {
            horizontalInput = Input.GetAxisRaw("Horizontal" + PlayerID);

            if (horizontalInput > 0 && leftTurn)
            {
                leftTurn = false;
                _monkeObject.DORotate(new Vector3(0, -45, 0), monkeyModelRotationSpeed);
            }

            if (horizontalInput < 0 && !leftTurn)
            {
                leftTurn = true;
                _monkeObject.DORotate(new Vector3(0, 45, 0), monkeyModelRotationSpeed);
            }

            if (Mathf.Abs(horizontalInput) > 0 && stopped)
            {
                stopped = false;
                _animator.SetTrigger("r");
            }

            if (Mathf.Abs(horizontalInput) == 0 && !stopped)
            {
                _animator.SetTrigger("rr");
                stopped = true;
            }

            playerRigidbody.velocity = new Vector2(horizontalInput * playerSpeed, playerRigidbody.velocity.y);
        }
    }

    private void Jump() => playerRigidbody.velocity = new Vector2(0, jumpPower);

    RaycastHit hit;

    private bool IsGrounded()
    {
        return (Physics.Raycast(DownRaycast_1.position, Vector3.down, raycastDistance)
            || (Physics.Raycast(DownRaycast_2.position, Vector3.down, raycastDistance)));
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
