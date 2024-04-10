using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WheelType
{
    None,
    Desert,
    Mountain,
    City
}

public enum EngineType
{
    SixEngine,
    EightEngine
}

public enum BoosterType
{
    SixBooster,
    EightBooster
}


public class PlayerCar : Car
{
    private PlayerSpeedUI playerSpeedUI;
    public static PlayerCar Instance;
    [SerializeField] private GameObject speedLine;
    [HideInInspector] public Inventory inventory;

    //[SerializeField] private GameObject[] playerMesh;
    [SerializeField] private MeshRenderer[] playerMesh;
    [SerializeField] private MeshRenderer[] shopModelMesh;
    [SerializeField] private Material[] wheelMesh;
    //[SerializeField] private GameObject[] shopModelMesh;
    //[SerializeField] private GameObject[] wheelMesh;

    [SerializeField] private GameObject shopModelBoost;
    [SerializeField] private GameObject playerBoost;
    [SerializeField] private GameObject booster;

    public static WheelType wheelType;
    public static BoosterType boosterType;
    public static EngineType engineType;


    protected override void Awake()
    {
        base.Awake();
        Instance = GetComponent<PlayerCar>();
        playerSpeedUI = GetComponent<PlayerSpeedUI>();
        inventory = GetComponent<Inventory>();
    }

    protected override void CarMove()
    {
        rigid.AddForce(MoveVec(), ForceMode.Acceleration);

        if (Mathf.Abs(Vector3.Distance(Vector3.zero, rigid.velocity)) * 2 > 100)
        {
            speedLine.SetActive(true);
        }
        else
        {
            speedLine.SetActive(false);
        }

        playerSpeedUI.SetSpeedText($"{Mathf.Abs(Vector3.Distance(Vector3.zero, rigid.velocity)) * 2:N0}");
    }

    protected override void CarRotation()
    {
        transform.Rotate(RotVec());
    }

    protected override Vector3 MoveVec()
    {
        float InputZ = Input.GetAxis("Vertical");
        return accelMoveSpeed * InputZ * transform.right;
    }

    protected override Vector3 RotVec()
    {
        float InputX = Input.GetAxis("Horizontal");
        return accelRotSpeed * InputX * Vector3.up;
    }

    public void ChangeWheelMesh(WheelType setWheelType)
    {
        wheelType = setWheelType;
        switch (setWheelType)
        {
            case WheelType.Desert:
                for (int i = 0; i < playerMesh.Length; i++)
                {
                    playerMesh[i].material = wheelMesh[0];
                    shopModelMesh[i].material = wheelMesh[0];
                    //playerMesh[i].gameObject.SetActive(false);
                    //shopModelMesh[i].gameObject.SetActive(false);
                    //wheelMesh[0].gameObject.SetActive(true);
                }
                break;
            case WheelType.Mountain:
                for (int i = 0; i < playerMesh.Length; i++)
                {
                    playerMesh[i].material = wheelMesh[1];
                    shopModelMesh[i].material = wheelMesh[1];
                    //playerMesh[i].gameObject.SetActive(false);
                    //shopModelMesh[i].gameObject.SetActive(false);
                    //wheelMesh[1].gameObject.SetActive(true);
                }
                break;
            case WheelType.City:
                for (int i = 0; i < playerMesh.Length; i++)
                {
                    playerMesh[i].material = wheelMesh[2];
                    shopModelMesh[i].material = wheelMesh[2];
                    //playerMesh[i].gameObject.SetActive(false);
                    //shopModelMesh[i].gameObject.SetActive(false);
                    //wheelMesh[2].gameObject.SetActive(true);
                }
                break;
        }
    }

    public void ChangeEngineMesh(EngineType setEngineType)
    {
        engineType = setEngineType;
        switch (setEngineType)
        {
            case EngineType.SixEngine:
                accelMoveSpeed = 150;
                break;
            case EngineType.EightEngine:
                accelMoveSpeed = 170;
                break;
        }
    }

    public void ChangeBoosterMesh(BoosterType setBoosterType)
    {
        boosterType = setBoosterType;
        playerBoost.gameObject.SetActive(true);
        shopModelBoost.gameObject.SetActive(true);
        switch (setBoosterType)
        {
            case BoosterType.SixBooster:
                boostTime = 2;
                break;
            case BoosterType.EightBooster:
                boostTime = 3;
                break;
        }
        booster.SetActive(true);
    }
}