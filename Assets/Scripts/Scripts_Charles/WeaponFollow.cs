using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFollow : MonoBehaviour
{
    [Header("Références")]
    [SerializeField] private Transform playerCamera; // La caméra du joueur
    [SerializeField] private Vector3 positionOffset; // Décalage de position relatif à la caméra
    [SerializeField] private Vector3 rotationOffset; // Décalage de rotation relatif à la caméra

    void LateUpdate()
    {
        if (playerCamera == null)
        {
            Debug.LogError("La référence à la caméra du joueur n'est pas assignée !");
            return;
        }

        // Positionner l'arme avec un décalage relatif à la caméra
        transform.position = playerCamera.position + playerCamera.TransformDirection(positionOffset);

        // Appliquer une rotation relative à la caméra
        transform.rotation = playerCamera.rotation * Quaternion.Euler(rotationOffset);
    }
}
