using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform m_cameraTransform;
    [SerializeField] private float m_moveDuration = 0.3f;

    public void MoveCamera(Vector3 position, Quaternion rotation)
    {
        StartCoroutine(AnimateCameraMovementCoroutine(position, rotation));
    }

    private IEnumerator AnimateCameraMovementCoroutine(Vector3 targetPosition, Quaternion targetRotation)
    {
        var startPosition = m_cameraTransform.position;
        var startRotation = m_cameraTransform.rotation;

        var accumTime = 0f;

        while (accumTime < m_moveDuration)
        {
            var t = accumTime / m_moveDuration;

            m_cameraTransform.position = Vector3.Lerp(startPosition, targetPosition, t);
            m_cameraTransform.rotation = Quaternion.Lerp(startRotation, targetRotation, t);

            accumTime += Time.deltaTime;

            yield return null;
        }

        m_cameraTransform.position = targetPosition;
        m_cameraTransform.rotation = targetRotation;
    }
}
