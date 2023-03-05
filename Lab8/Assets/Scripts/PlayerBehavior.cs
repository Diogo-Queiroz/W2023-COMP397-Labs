using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [Header("Player Data")] 
    public string playerName;
    public int playerHealth;
    public int playerLevel;

    [Header("Character Controller")]
    public CharacterController controller;

    [Header("Controls")] 
    public Joystick joystick;
    public float horizontalSensitivity;
    public float verticalSensitivity;

    [Header("Movement")]
    public float maxSpeed = 10.0f;
    public float gravity = -30.0f;
    public float jumpHeight = 3.0f;
    public Vector3 velocity;
    
    [Header("Jump")]
    public Transform groundCheck;
    public float groundRadius = 0.5f;
    public LayerMask groundMask;
    public bool isGrounded;
    
    [Header("Health")]
    [SerializeField] private HealthSystem _healthSystem;

    private Vector3 startPosition;
    private bool _coroutineIsRunning = false;

    private void Awake()
    {
        startPosition = transform.position;
    }

    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);
        if (isGrounded && velocity.y < 0.0f)
        {
            velocity.y = -2.0f;
        }

        // Movement Section
#if !UNITY_ANDROID
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
#elif UNITY_ANDROID
        float x = joystick.Horizontal;
        float y = joystick.Vertical;
#endif
        Vector3 move = transform.right * x + transform.forward * y;
        controller.Move(move * maxSpeed * Time.deltaTime);

        // Jump Section
#if !UNITY_ANDROID
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
#endif
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathArea"))
        {
            GetComponent<CharacterController>().enabled = false;
            transform.position = startPosition;
            GetComponent<CharacterController>().enabled = true;
        }
        if (other.CompareTag("HealthPack"))
        {
            if (_healthSystem.health < _healthSystem.maxHearts)
            {
                _healthSystem.SelfHeal();
                other.gameObject.SetActive(false);
            }
        }
        if (other.CompareTag("HealthUpgrade"))
        {
            _healthSystem.IncreaseHeart();
            other.gameObject.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("DamageArea") && !_coroutineIsRunning)
        {
            _coroutineIsRunning = true;
            StartCoroutine(DoDamageOverTime());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("DamageArea"))
        {
            StopCoroutine(DoDamageOverTime());
            _coroutineIsRunning = false;
        }
    }

    private IEnumerator DoDamageOverTime()
    {
        int counter = _healthSystem.health;
        while (counter > 0 && _coroutineIsRunning)
        {
            _healthSystem.Damage();
            yield return new WaitForSeconds(2f);
            counter--;
        }

        yield return null;
    }

    public void SaveButton_Pressed()
    {
        SaveSystem.SavePlayer(this.GetComponent<PlayerBehavior>());
    }
    public void LoadButton_Pressed()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if (data != null)
        {
            playerName = data.name;
            playerHealth = data.health;
            playerLevel = data.level;
        }
    }

    private void Jump()
    {
        velocity.y = MathF.Sqrt(jumpHeight * -2.0f * gravity);
        AudioController.Instance.PlaySFXAudio("hop4");
    }

    public void JumpButtonPressed()
    {
        if (isGrounded)
        {
            Jump();
        }
    }
}
