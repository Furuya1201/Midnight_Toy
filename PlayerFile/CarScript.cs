using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//使用の有無をinspector上で変更
[System.Serializable]
public class AxleInfo
{

    public WheelCollider leftWheel;      //左タイヤのコライダーを格納
    public WheelCollider rightWheel;     //右タイヤのコライダーを格納
    public GameObject visualLeftWheel;   //右タイヤを格納
    public GameObject visualRightWheel;  //左タイヤを格納

    public bool motor;     //モーターを使うかどうか
    public bool steering;  //角度を変更するかどうか
    public bool brake;     //ブレーキを使うかどうか

}

public class CarScript : MonoBehaviour
{

    public List<AxleInfo> axleInfos;
    [SerializeField] public float maxMotorTorque;    //最大出力値
    [SerializeField] public float maxBrakeTorque;    //最大ブレーキ値
    [SerializeField] public float maxSteeringAngle;  //最大カーブ角度

    private float steering = 0.0f;  //カーブ角度の入力値格納
    private float motor = 0.0f;     //モーターの入力値格納

    private bool brake;  //Keyが押されたかの判定

    private void Start()
    {

    }

    //コライダーに反映されている角度によって、可視化されるObjectも角度変更
    private void ApplyLocalPositionToVisuals(GameObject _gameObject, WheelCollider collider)
    {

        //Objectno角度格納
        Transform visualWheel = _gameObject.transform;

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        //現在の角度とポジションを反映
        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;

    }

    private void FixedUpdate()
    {

        //入力との計算で、各値を格納
        motor = maxMotorTorque * Input.GetAxis("Vertical");
        steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        brake = Input.GetKey(KeyCode.LeftShift);

        //List内の値を、使用の有無や状態によって反映する
        foreach (AxleInfo axleInfo in axleInfos)
        {

            //角度
            if (axleInfo.steering)
            {

                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;

            }

            //モーター
            if (axleInfo.motor)
            {

                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;

            }

            //ブレーキ
            if (axleInfo.brake && brake)
            {

                axleInfo.leftWheel.brakeTorque = maxBrakeTorque;
                axleInfo.rightWheel.brakeTorque = maxBrakeTorque;

            }
            else
            {

                axleInfo.leftWheel.brakeTorque = 0;
                axleInfo.rightWheel.brakeTorque = 0;

            }

            //現在の角度によって、Objectの角度も変更
            ApplyLocalPositionToVisuals(axleInfo.visualLeftWheel, axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.visualRightWheel, axleInfo.rightWheel);

        }

    }

}
