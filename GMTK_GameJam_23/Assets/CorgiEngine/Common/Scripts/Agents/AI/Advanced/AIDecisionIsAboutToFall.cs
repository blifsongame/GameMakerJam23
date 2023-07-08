using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

namespace MoreMountains.CorgiEngine
{
	public class AIDecisionIsAboutToFall : AIDecision
	{
		protected CorgiController _controller;
		protected Character _character;
		protected float _startTime = 0f;
		protected Vector2 _raycastOrigin;

		/// The offset the hole detection should take into account
		[Tooltip("The offset the hole detection should take into account")]
		public Vector3 HoleDetectionOffset = new Vector3(1, 0, 0);
		/// the length of the ray cast to detect holes
		[Tooltip("the length of the ray cast to detect holes")]
		public float HoleDetectionRaycastLength = 1f;

		/// <summary>
		/// On init we grab our CorgiController component
		/// </summary>
		public override void Initialization()
		{
			base.Initialization();
			_controller = this.gameObject.GetComponentInParent<CorgiController>();
			_character = this.gameObject.GetComponentInParent<Character>();
		}

		public override bool Decide()
		{
			if (!_controller.State.IsGrounded)
			{
				return false;
			}

			if (_character.IsFacingRight)
			{
				_raycastOrigin = transform.position + (_controller.Bounds.x / 2 + HoleDetectionOffset.x) * transform.right + HoleDetectionOffset.y * transform.up;
			}
			else
			{
				_raycastOrigin = transform.position - (_controller.Bounds.x / 2 + HoleDetectionOffset.x) * transform.right + HoleDetectionOffset.y * transform.up;
			}

			RaycastHit2D raycast = MMDebug.RayCast(_raycastOrigin, -transform.up, HoleDetectionRaycastLength, _controller.PlatformMask | _controller.MovingPlatformMask | _controller.OneWayPlatformMask | _controller.MovingOneWayPlatformMask, Color.gray, true);

			// if the raycast doesn't hit anything
			if (!raycast)
			{
				// we change direction
				return true;
			}

			return false;
		}

		private bool CheckForHoles()
		{
			if (!_controller.State.IsGrounded)
			{
				return false;
			}

			if (_character.IsFacingRight)
			{
				_raycastOrigin = transform.position + (_controller.Bounds.x / 2 + HoleDetectionOffset.x) * transform.right + HoleDetectionOffset.y * transform.up;
			}
			else
			{
				_raycastOrigin = transform.position - (_controller.Bounds.x / 2 + HoleDetectionOffset.x) * transform.right + HoleDetectionOffset.y * transform.up;
			}

			RaycastHit2D raycast = MMDebug.RayCast(_raycastOrigin, -transform.up, HoleDetectionRaycastLength, _controller.PlatformMask | _controller.MovingPlatformMask | _controller.OneWayPlatformMask | _controller.MovingOneWayPlatformMask, Color.gray, true);

			// if the raycast doesn't hit anything
			if (!raycast)
			{
				// we change direction
				return true;
			}

			return false;
		}
	}
}
