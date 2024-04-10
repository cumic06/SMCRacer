using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public enum CarType
{
    Player,
    Enemy
}

[RequireComponent(typeof(Rigidbody))]
public abstract class Car : MonoBehaviour
{
    protected Rigidbody rigid;
    [SerializeField] protected float accelMoveSpeed;
    [SerializeField] protected float accelRotSpeed;
    [SerializeField] protected float dragSpeed;

    public CarType carType;

    public int lap;
    public int trackIndex;

    [SerializeField] protected LayerMask FloorLayer;
    [SerializeField] protected float resetTime;
    protected float currentResetTime;

    [SerializeField] protected GameObject targetPoint;
    protected bool isTarget = false;
    GameObject spawnTarget;

    [SerializeField] protected GameObject boostEffect;

    [SerializeField] protected float boostTime;

    [SerializeField] AudioClip boostSound;

    public bool isBoost;

    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    protected virtual void FixedUpdate()
    {
        SetTrackIndex();
        CheckFloor();
        CarMove();
        CarRotation();
        rigid.drag = dragSpeed;
    }

    protected abstract void CarMove();
    protected abstract void CarRotation();

    protected abstract Vector3 MoveVec();
    protected abstract Vector3 RotVec();

    public void SetDrag(int value)
    {
        dragSpeed = value;
    }

    public IEnumerator SetMoveSpeed(float value)
    {
        accelMoveSpeed += value;
        if (carType == CarType.Player && isBoost)
        {
            SoundSystem.Instance.SfxPlay(boostSound, 0.5f);
            boostEffect.SetActive(true);
        }
        yield return new WaitForSeconds(boostTime);
        isBoost = false;
        accelMoveSpeed -= value;
        if (carType == CarType.Player)
        {
            boostEffect.SetActive(false);
        }
    }

    protected virtual void CheckFloor()
    {
        RaycastHit[] floorHit = Physics.BoxCastAll(transform.position, Vector3.one, -transform.up, Quaternion.identity, 1, FloorLayer);

        if (floorHit.Length < 1)
        {
            if (currentResetTime >= resetTime)
            {
                ResetCar();
            }
            else
            {
                currentResetTime += Time.deltaTime;
            }
        }
        else
        {
            currentResetTime = 0;
        }
    }

    public virtual void ResetCar()
    {
        currentResetTime = 0;
        transform.rotation = Quaternion.identity;
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
        transform.position = TrackManager.Instance.TrackList[trackIndex].position + Vector3.up;
    }

    protected void SetTrackIndex()
    {

        if (trackIndex >= TrackManager.Instance.TrackList.Count - 1)
        {
            trackIndex = 0;
            AddLap();
        }

        if (carType == CarType.Player)
        {
            if (!isTarget)
            {
                spawnTarget = Instantiate(targetPoint);
                spawnTarget.transform.position = TrackManager.Instance.TrackList[trackIndex + 1].position;
                isTarget = true;
            }
        }

        if (TrackManager.Instance.CloseTrackPos(transform.position, trackIndex))
        {
            trackIndex++;

            if (carType == CarType.Player)
            {
                isTarget = false;
                Destroy(spawnTarget);
            }

            if (trackIndex >= TrackManager.Instance.TrackList.Count - 1)
            {
                trackIndex = 0;
                AddLap();
                return;
            }
        }
    }

    protected void AddLap()
    {
        lap++;
        if (carType == CarType.Player)
        {
            InGameUIManager.Instance.SetLapText($"{lap}/{TrackManager.Instance.MaxLap}");
            InGameUIManager.Instance.SetLapTimeText($"{TimeManager.Instance.Min:00}:{TimeManager.Instance.time:N3}");
        }

        if (lap >= TrackManager.Instance.MaxLap)
        {
            GameManager.Instance.GameEnd(carType);
        }
    }
}