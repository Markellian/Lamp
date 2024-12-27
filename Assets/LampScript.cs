using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LampScript : MonoBehaviour
{
    bool _switchOn;
    float _speed = 3f;
    float _intensity = 6;
    Light _lightSourseLightComponent;
    Light _bulbLightComponent;

    [SerializeField]
    public GameObject lightSourse;
    public GameObject bulb;
    public TextMeshProUGUI textButtom;

    public void SwitchLamp()
    {
        if (_switchOn)
        {
            _switchOn = false;
            textButtom.text = "Включить";
        }
        else
        {
            _switchOn = true;
            textButtom.text = "Выключить";
        }
    }
    void Awake()
    {
        _lightSourseLightComponent = lightSourse.GetComponent<Light>();
        _bulbLightComponent = bulb.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_switchOn)
        {
            if (_bulbLightComponent.intensity < _intensity)
            {
                _bulbLightComponent.intensity += Time.deltaTime * _speed;
                _lightSourseLightComponent.intensity = _bulbLightComponent.intensity * 0.1f;
            }
        }
        else
        {
            if (_bulbLightComponent.intensity >= 0)
            {
                _bulbLightComponent.intensity -= Time.deltaTime * _speed;
                _lightSourseLightComponent.intensity = _bulbLightComponent.intensity * 0.1f;
            }
        }
    }

}
