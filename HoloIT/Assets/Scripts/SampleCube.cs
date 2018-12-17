using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCube : MonoBehaviour, IInputClickHandler
{
    public Material red;
    public Material blue;
    public Material green;

    private MeshRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        SpeechManager.Instance.OnTextReceived += Instance_OnTextReceived;
    }

    private void Instance_OnTextReceived(object response)
    {
        var result = (RecognitionResult)response;

        if (result.DisplayText.ToUpper().Contains("ROSSO"))
            RedCommand();
        if (result.DisplayText.ToUpper().Contains("VERDE"))
            GreenCommand();
        if (result.DisplayText.ToUpper().Contains("BLU"))
            BlueCommand();
    }

    public void RedCommand()
    {
        _renderer.material = red;
    }
    public void GreenCommand()
    {
        _renderer.material = green;
    }
    public void BlueCommand()
    {
        _renderer.material = blue;
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        SpeechManager.Instance.Recognize();
    }

}
