using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerMoveSpeed = 2.0f;
    public float leftLim  = -5.0f;
    public float rightLim =  5.0f;

    private float interval = .0f;
    private ObjectPool bulletPool;

    private void Start() => bulletPool = StageContoller.Instance.p_BulletPool;

    void Update() => interval -= Time.deltaTime;


    /// <summary>
    //  /移動処理
    /// </summary>
    public void PlayerMovement(float horizontal , Vector3 currentPosition)
    {
        currentPosition    = this.transform.localPosition;
        float newXPosition = currentPosition.x + horizontal * Time.deltaTime * playerMoveSpeed;

        newXPosition = Mathf.Clamp(newXPosition , leftLim , rightLim);

        transform.position = new Vector2(newXPosition, -4.0f);
    }


    /// <summary>
    /// 射撃の処理
    /// </summary>
    public void Shot()
    {
        if (interval <= .0f)
        {
            var bullet = bulletPool.Launch(this.transform.position, 0);

            if (bullet != null)
                bullet.GetComponent<BulletMove>().speed = 10;

            interval = .7f;
        }
    }
}
