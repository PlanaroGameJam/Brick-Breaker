using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Serializable]
    public struct Controller
    {
        public InputActionAsset inputActionAsset;

        public void Enable()
        {
            if(inputActionAsset.name.Contains("Title"))
            {
                var titleScene = GameObject.FindWithTag("Scene").GetComponent<TitleScene>();
                var ui = inputActionAsset.FindActionMap("UI");
                ui.FindAction("Enter").started += titleScene.Enter;
                ui.Enable();
            }
            else if (inputActionAsset.name.Contains("Tutorial"))
            {

            }
            else if (inputActionAsset.name.Contains("Play"))
            {

            }
            else if (inputActionAsset.name.Contains("Result"))
            {

            }

        }

        public void Disable()
        {
            if (inputActionAsset.name.Contains("Title"))
            {
                var titleScene = GameObject.FindWithTag("Scene").GetComponent<TitleScene>();
                var ui = inputActionAsset.FindActionMap("UI");
                ui.FindAction("Enter").started -= titleScene.Enter;
                ui.Disable();
            }
            else if (inputActionAsset.name.Contains("Tutorial"))
            {

            }
            else if (inputActionAsset.name.Contains("Play"))
            {

            }
            else if (inputActionAsset.name.Contains("Result"))
            {

            }

        }
    }

    [SerializeField]
    List<InputActionAsset> m_inputActionAssetsList;

    public Controller m_controller;

    private void OnEnable()
    {
        m_controller.inputActionAsset = m_inputActionAssetsList.Find(inputActionAsset => inputActionAsset.name == SceneManager.GetActiveScene().name);
        m_controller.Enable();
    }

    public void Disable()
    {
        m_controller.Disable();
    }

}
