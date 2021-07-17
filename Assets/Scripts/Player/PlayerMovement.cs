using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 2;
        public float jumpForce = 2;
        private Rigidbody2D _rb;
        private bool _isJumping;
        private bool _isScared;

        // MonoBehaviour methods
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        
        private void Update()
        {
            HandleJump();
            HandleScared();
        }
        private void FixedUpdate()
        {
            HandleMovementInput();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Ground"))
            {
                _isJumping = false;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.collider.CompareTag("Ground"))
            {
                _isJumping = true;
            }
        }

        // Custom methods
        private void HandleMovementInput()
        {
            var direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            _rb.AddForce(direction.normalized * speed);
        }

        private void HandleJump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !_isJumping)
            {
                _rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }

        private void HandleScared()
        {
            // For debug
            if (Input.GetKeyDown(KeyCode.F))
            {
                _isScared = !_isScared;
                Debug.Log(_isScared);
            }
            Time.timeScale = _isScared ? 0.5f : 1;
        }
        
    }
}