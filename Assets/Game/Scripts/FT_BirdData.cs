using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BirdData", menuName = "ScriptableObjects/BirdData", order = 1)]
public class FT_BirdData : ScriptableObject
{
    [SerializeField] float speed = 20;
    public float Speed { get { return speed / 100; } }

    [SerializeField] float birdRotationCoef = 20;
    public float BirdRotationCoef { get { return birdRotationCoef / 100; } }

    [SerializeField] float birdZRotationCoef = 20;
    public float BirdZRotationCoef { get { return birdZRotationCoef / 100; } }


    [SerializeField] float birdRotationSpeed = 20;
    public float BirdRotationSpeed { get { return birdRotationSpeed / 100; } }

    [SerializeField] float birdHoverSpeed = 20;
    public float BirdHoverSpeed { get { return birdHoverSpeed / 100; } }


    [SerializeField] float birdZRotationClamp = 20;
    public float BirdZRotationClamp { get { return birdZRotationClamp; } }

    [SerializeField] float birdVerticalClamp = 20;
    public float BirdVerticalClamp { get { return birdVerticalClamp; } }



}
