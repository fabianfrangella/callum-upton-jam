using UnityEngine;

namespace Player
{
    public class CameraFollower : MonoBehaviour
    {
        public Transform player;

        // Desired duration of the shake effect
        private float shakeDuration = 0f;
 
        // A measure of magnitude for the shake. Tweak based on your preference
        private const float ShakeMagnitude = 0.1f;
 
        // A measure of how quickly the shake effect should evaporate
        private const float DampingSpeed = 2f;

        private void Update()
        {
            Shake();
            SetCameraPosition();
        }

        private void SetCameraPosition()
        {
            var cameraMoveDir = (player.position - transform.position).normalized;
            var distance = Vector2.Distance(player.position, transform.position);
            var playerPositionOffset = new Vector3(player.position.x, player.position.y + 4f, player.position.z);
            const float cameraMoveSpeed = 70f;
            if (distance > 0)
            {
                var newCameraPosition = transform.position + cameraMoveDir * distance * cameraMoveSpeed * Time.deltaTime;
                var distanceAfterMoving = Vector2.Distance(newCameraPosition, playerPositionOffset);

                transform.position = distanceAfterMoving > distance ? playerPositionOffset : newCameraPosition;
            }

            transform.position = new Vector3(transform.position.x, playerPositionOffset.y, -10);
        }

        private void Shake()
        {
            if (shakeDuration > 0)
            {
                transform.localPosition = transform.position + Random.insideUnitSphere * ShakeMagnitude;
                shakeDuration -= Time.deltaTime * DampingSpeed;
            }
        }

        private void SetShakeDuration()
        {
            shakeDuration = 0.2f;
        }
    }
}