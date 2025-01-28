using UnityEngine;

public class GunController : MonoBehaviour
{
    public Animator animator; // Assign in Inspector
    public Camera playerCamera;
    public AudioSource gunFireSound; // Assign in Inspector
    public ParticleSystem muzzleFlash; // Assign in Inspector

    public float fireRate = 0.2f; // Fire rate in seconds (adjust as needed)
    private float nextFireTime = 0f; // Tracks when the player can shoot again

    void Update()
    {
        // Right-click to aim
        if (Input.GetMouseButton(1)) // Right Mouse Button
        {
            animator.SetBool("isAiming", true);
        }
        else
        {
            animator.SetBool("isAiming", false);
        }

        // Left-click to shoot (Only if aiming & fire rate cooldown allows)
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate; // Set next fire time
            animator.SetBool("Shoot", true);
            PlayGunEffects();
        }
        else
        {
            animator.SetBool("Shoot", false);
        }
    }

    void PlayGunEffects()
    {
        if (gunFireSound != null)
        {
            gunFireSound.Play(); // Play gunfire sound
        }

        if (muzzleFlash != null)
        {
            muzzleFlash.Play(); // Play muzzle flash effect
        }
    }
}
