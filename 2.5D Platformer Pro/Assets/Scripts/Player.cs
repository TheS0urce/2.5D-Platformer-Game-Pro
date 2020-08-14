using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _gravity = 1.0f;
    [SerializeField]
    private float _jumpHeight = 20.0f;

    private CharacterController _controller;
    private float _yVelocity;
    private bool _canDoubleJump = false;

    // variable player coins
    private int _coins;
    private UIManager _uIManager;
    [SerializeField]
    private int _lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if(_uIManager == null)
        {
            Debug.LogError("UI Manager is NULL");
        }

        _uIManager.UpdateLivesDisplay(_lives);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * _speed;

        //if grounded
        //do nothing
        //else
        //apply gravity

        //velocity.y - _gravity

        if (_controller.isGrounded == true)
        {
            //if hit space key
            //jump

            if(Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }

        }

        //check for double jump
        //current _yvelocity += jumpheight

        else 
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(_canDoubleJump == true)
                {
                    _yVelocity += _jumpHeight;
                    _canDoubleJump = false;
                }
            }

            _yVelocity -= _gravity;
        }

        
        velocity.y = _yVelocity;

        _controller.Move(velocity * Time.deltaTime);
    }

    public void CollectCoin()
    {
        _coins++;

        if(_uIManager != null)
        {
            _uIManager.UpdateCoinDisplay(_coins);
        }
    }

    public void Damage()
    {
        _lives--;
        _uIManager.UpdateLivesDisplay(_lives);

        if(_lives < 1)
        {
            SceneManager.LoadScene(0);
        } 
    }
}
