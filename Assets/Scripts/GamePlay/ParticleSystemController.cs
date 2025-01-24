using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    ParticleSystem particleSystem;
    [SerializeField] KeyCode nitroActivationButton;

    // Private backing field
    private bool isNitroActive;

    // Public property to expose the backing field
    public bool IsNitroActive {get => isNitroActive; } // Getter returns the field
    void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(nitroActivationButton))
        {
            if (!isNitroActive)
            {
                particleSystem.Play();
                isNitroActive = true;
            }
            else
            {
                particleSystem.Stop();
                isNitroActive = false;
            }
        }

    }
}
