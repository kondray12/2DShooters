using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target; // Ссылка на объект, за которым будет следить камера
    public float smoothSpeed = 0.125f; // Сглаживание движения камеры
    public Vector3 offset; // Отступ камеры от цели

    void LateUpdate()
    {
        if (target != null)
        {
            // Вычисляем желаемую позицию камеры
            Vector3 desiredPosition = target.position + offset;

            // Сглаживаем движение камеры к желаемой позиции
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Устанавливаем позицию камеры
            transform.position = smoothedPosition;

            // Направляем камеру на цель
            transform.LookAt(target);
        }
    }
}
