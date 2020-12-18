using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FT_Bird : MonoBehaviour
{
    [SerializeField] Vector2 input = Vector2.zero;
    [SerializeField] FT_BirdData data = null;
    [SerializeField] GameObject render = null;

    bool torqueGoUp = true;
    bool renderGoUp = true;
    float z = 0;
    float y = 0;


    private void Update()
    {

        // move bird in his forward
        transform.position += transform.forward * (data.Speed);


        //rotate bird on inputs & adds torque on z axis
        transform.eulerAngles = new Vector3(
            ClampAngle(transform.eulerAngles.x + input.y, -data.BirdVerticalClamp, data.BirdVerticalClamp),
            transform.eulerAngles.y + input.x * (data.BirdRotationCoef),
            ClampAngle(transform.eulerAngles.z - input.x * (data.BirdZRotationCoef), -data.BirdZRotationClamp, data.BirdZRotationClamp));


        if (Mathf.Abs(input.x) < .1f)
        {
            if (transform.eulerAngles.z > .1f)
            {
                transform.eulerAngles = AngleLerp(transform.eulerAngles, new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0), Time.deltaTime * (data.BirdRotationSpeed));
                render.transform.eulerAngles = AngleLerp(render.transform.eulerAngles, new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0), Time.deltaTime * (data.BirdRotationSpeed));
            }
            else
            {
                if (z > 4)
                    torqueGoUp = false;
                if (z < -4)
                    torqueGoUp = true;

                z = Mathf.MoveTowards(z, torqueGoUp ? 5 : -5, Time.deltaTime * (data.BirdRotationSpeed));

                render.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, z);
            }
        }

        if (Mathf.Abs(input.y) < .1f && Mathf.Abs(input.x) < .1f)
        {
            if (transform.eulerAngles.x > .1f)
            {
                transform.eulerAngles = AngleLerp(transform.eulerAngles, new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z), Time.deltaTime * (data.BirdHoverSpeed));
                render.transform.localPosition = Vector3.MoveTowards(render.transform.localPosition, Vector3.zero, Time.deltaTime * data.BirdHoverSpeed);
            }
            if (y > .1f)
                renderGoUp = false;
            if (y < -.1f)
                renderGoUp = true;

            y = (Mathf.MoveTowards(y, renderGoUp ? .2f : -.2f, Time.deltaTime * data.BirdHoverSpeed));

            render.transform.localPosition = new Vector3(0, y, 0);

        }
    }

    // Receive inputs & set them in "inputs"
    public void Move(InputAction.CallbackContext _ctx)
    {
        if (_ctx.valueType != typeof(Vector2))
            return;

        input = _ctx.ReadValue<Vector2>();
    }


    Vector3 AngleLerp(Vector3 _startAngle, Vector3 _finishAngle, float _t)
    {
        float _xLerp = Mathf.LerpAngle(_startAngle.x, _finishAngle.x, _t);
        float _yLerp = Mathf.LerpAngle(_startAngle.y, _finishAngle.y, _t);
        float _zLerp = Mathf.LerpAngle(_startAngle.z, _finishAngle.z, _t);
        Vector3 _lerped = new Vector3(_xLerp, _yLerp, _zLerp);
        return _lerped;
    }

    float ClampAngle(float _angle, float _angleMin, float _angleMax)
    {
        if (_angle < 90 || _angle > 270)
        {
            if (_angle > 180) _angle -= 360;
            if (_angle > 180) _angleMax -= 360;
            if (_angleMin > 180) _angleMin -= 360;
        }
        _angle = Mathf.Clamp(_angle, _angleMin, _angleMax);
        return _angle;
    }


    private void OnTriggerEnter(Collider other)
    {
        // A voir en fonction des bonus/malus
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Die ou life--
    }


}
