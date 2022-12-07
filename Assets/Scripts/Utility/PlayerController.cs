using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    private ControlActions m_controlActions;

    private void OnEnable()
    {
        m_controlActions = new ControlActions();
        Enable();
    }

    public void Enable()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName.Contains("Title"))
        {

        }
        else if (currentSceneName.Contains("Tutorial"))
        {

        }
        else if (currentSceneName.Contains("Play"))
        {
            var paddle = GameObject.FindWithTag("Paddle").GetComponent<Paddle>();
            m_controlActions.Play.Move.performed += paddle.Move;

            m_controlActions.Play.Click.started += paddle.Click;
            m_controlActions.Play.Click.performed += paddle.ChargePower;
            m_controlActions.Play.Click.canceled += paddle.JustRelease;

            m_controlActions.Enable();
        }
        else if (currentSceneName.Contains("Result"))
        {

        }

    }

    public void Disable()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName.Contains("Title"))
        {

        }
        else if (currentSceneName.Contains("Tutorial"))
        {

        }
        else if (currentSceneName.Contains("Play"))
        {
            var paddle = GameObject.FindWithTag("Paddle").GetComponent<Paddle>();
            m_controlActions.Play.Move.performed -= paddle.Move;

            m_controlActions.Play.Click.started -= paddle.Click;
            m_controlActions.Play.Click.performed -= paddle.ChargePower;
            m_controlActions.Play.Click.canceled -= paddle.JustRelease;

            m_controlActions.Disable();
        }
        else if (currentSceneName.Contains("Result"))
        {

        }
    }


}
