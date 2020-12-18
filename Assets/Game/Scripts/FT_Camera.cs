using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FT_Camera : MonoBehaviour
{


    [SerializeField] GameObject toFollow = null;
    [SerializeField] float camSpeed = 10;
    [SerializeField] float heightOffset = 2;

    private void Start()
    {
        transform.position = toFollow.transform.position - (toFollow.transform.forward * 10) + Vector3.up * heightOffset;
    }

    private void LateUpdate()
    {
        if(toFollow)
        {
            transform.LookAt(toFollow.transform.position + (Vector3.up * heightOffset));
            transform.position = Vector3.Lerp(transform.position, toFollow.transform.position - (toFollow.transform.forward * 10) + (Vector3.up * heightOffset), Time.time * (camSpeed / 100));
        }
    }


    public void SetToFollow(GameObject _go) => toFollow = _go;
    public void ResetToFollow() => toFollow = null;




}
