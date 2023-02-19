using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
	public enum CameraState
	{
		Idle,
		FocusOn,
	}
	public class CameraManager : MonoSingleton<CameraManager>
	{
		private Camera _mainCamera;
		public Camera mainCamera => _mainCamera;
		public Vector3 cameraFocusOn = Vector3.zero;

		private CameraState _cameraState;
		public CameraState cameraState => _cameraState;
		

		protected override void Awake()
		{
			base.Awake();
			_mainCamera = GetComponent<Camera>();
		}

		private void Update()
		{
			switch(_cameraState)
			{
				case CameraState.Idle:
					break;
				case CameraState.FocusOn:
					FocusOn(cameraFocusOn);
					break;
				default:
					break;

			}
		}


		public void FocusOn(Vector3 point)
		{
			if (_mainCamera != null)
			{
				_mainCamera.transform.LookAt(point);
			}
		}

		public void SwitchTo(CameraState nextState)
		{
			Debug.Log(string.Format("CameraState Switch: {0} To {1}", _cameraState, nextState));
			_cameraState = nextState;
		}
	}
}

