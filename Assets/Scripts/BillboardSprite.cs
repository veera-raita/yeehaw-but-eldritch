using UnityEngine;
using System.Collections;

public class BillboardSprite : MonoBehaviour
{

	public Transform m_CameraTransform;
	private Transform m_LocalTransform;
	public bool alignNotLook = true;

	// Use this for initialization
	void Start()
	{
		m_LocalTransform = transform;
		m_CameraTransform = Camera.main.transform;
	}

	// Update is called once per frame
	void LateUpdate()
	{
		if (alignNotLook)
			m_LocalTransform.forward = m_CameraTransform.forward;
		else
			m_LocalTransform.LookAt(m_CameraTransform, Vector3.up);
	}
}