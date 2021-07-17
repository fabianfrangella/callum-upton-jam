using System;
using Pathfinding;
using UnityEngine;

namespace Enemy.PathFinding
{
    public class EnemyPathFinder : MonoBehaviour
    {
        public float nextWaypointDistance = 1f;
        public float speed = 10;
        private Seeker _seeker;
        private Path _path;
        public Transform _target;
        private Rigidbody2D _rb;
        private int _currentWaypoint = 0;
        private bool _hasReachedPlayer;
        private void Start()
        {
            _seeker = GetComponent<Seeker>();
            _rb = GetComponent<Rigidbody2D>();
            InvokeRepeating(nameof(UpdatePath), 0f,0.5f);
        }

        private void FixedUpdate()
        {
            if (_path == null || _hasReachedPlayer) return;
            MoveTowardsWaypoint();
            SetNextWaypoint();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _hasReachedPlayer = other.collider.CompareTag("Player");
            if (_hasReachedPlayer) _rb.velocity = Vector2.zero;
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.collider.CompareTag("Player")) _hasReachedPlayer = false;
        }

        private void UpdatePath()
        {
            if (_target == null || !_seeker.IsDone()) return;
            _seeker.StartPath(transform.position, _target.position, OnPathComplete);
        }
        
        private void OnPathComplete(Path p)
        {
            if (p.error) return;
            _path = p;
            _currentWaypoint = 0;
        }
        
        private void MoveTowardsWaypoint()
        {
            if (_path.vectorPath.Count <= _currentWaypoint) return;
            var dir = ((Vector2) _path.vectorPath[_currentWaypoint] - _rb.position).normalized;
            _rb.velocity = dir * speed;
        }
        
        private void SetNextWaypoint()
        {
            if (_path.vectorPath.Count <= _currentWaypoint) return;
        
            var distance = Vector2.Distance(_rb.position, _path.vectorPath[_currentWaypoint]);
        
            if (distance < nextWaypointDistance)
            {
                _currentWaypoint++;
            }
        }
    }
}