﻿using UnityEngine;
using System.Collections;

//シューティング エネミー
public class STGEnemy : MonoBehaviour
{
    public bool Normal;   //通常エネミー
    public bool Attacker;   //攻撃エネミー
    public bool Shilder;   //盾エネミー

    public float speed; //移動速度
    public int getScore;    //スコア
    public GameObject Piece;    //死亡エフェクト

    public GameObject Shot; //弾
    public float intervalTime;  //発射間隔
    float interval;


    //敵の状態
    enum EnemyState
    {
        Normal,  //通常
        Active,   //異常
    }
    EnemyState enemyState = EnemyState.Normal;

    //状態チェンジまでの時間
    public float activeTime;
    float active;


    void Start()
    {
        interval = 0;
        active = 0;

        //サウンドロードSpawn
        SoundMgr.SoundLoadSe("Shot", "Shot");
        SoundMgr.SoundLoadSe("Death", "Death");
    }


    void Update()
    {
        if (Normal) { NormalMove(); }
        if (Attacker) { AttackMove(); }
        if (Shilder) { ShildMove(); }
    }


    //行動
    public void NormalMove()
    {
        switch (enemyState)
        {
            //通常
            case EnemyState.Normal:
                //ステータス変更
                active += Time.deltaTime;
                if (active >= activeTime)
                {
                    enemyState = EnemyState.Active;
                    Debug.Log(enemyState);
                }

                //移動
                transform.Translate(0, 0, speed);
                break;

            //時間経過
            case EnemyState.Active:
                //移動
                transform.Translate(0, 0, speed * 2.0f);
                break;
        }
    }

    public void AttackMove()
    {
        switch (enemyState)
        {
            //通常
            case EnemyState.Normal:
                //ステータス変更
                active += Time.deltaTime;
                if (active >= activeTime)
                {
                    enemyState = EnemyState.Active;
                    Debug.Log(enemyState);
                }

                //移動
                transform.Translate(0, 0, speed);

                //攻撃
                interval += Time.deltaTime;
                if (interval >= intervalTime)
                {
                    interval = 0.0f;

                    //弾
                    Instantiate(Shot, new Vector3(transform.position.x,
                                                  transform.position.y,
                                                  transform.position.z - 1),
                                                  Quaternion.identity);

                    //音
                    SoundMgr.PlaySe("Shot", 3);
                }
                break;

            //時間経過
            case EnemyState.Active:
                //移動
                transform.Translate(0, 0, speed * 3.0f);

                //攻撃
                interval += Time.deltaTime;
                if (interval >= 3)
                {
                    interval = 0.0f;

                    //弾
                    Instantiate(Shot, new Vector3(transform.position.x,
                                                  transform.position.y,
                                                  transform.position.z - 1),
                                                  Quaternion.identity);

                    //音
                    SoundMgr.PlaySe("Shot", 3);
                }
                break;
        }
    }

    public void ShildMove()
    {
        switch (enemyState)
        {
            //通常
            case EnemyState.Normal:
                //ステータス変更
                active += Time.deltaTime;
                if (active >= activeTime)
                {
                    enemyState = EnemyState.Active;
                    Debug.Log(enemyState);
                }

                //移動
                transform.Translate(0, 0, speed);
                break;

            //時間経過
            case EnemyState.Active:
                break;
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        //弾
        if (collision.gameObject.tag == "Shot")
        {
            //当たったら消える
            Destroy(this.gameObject);

            //スコア
            Score.score += getScore;

            //エフェクト
            Instantiate(Piece, new Vector3(transform.position.x,
                                           transform.position.y,
                                           transform.position.z),
                                           Quaternion.identity);

            //音
            SoundMgr.PlaySe("Death", 4);
        }

        //壁
        if (collision.gameObject.tag == "Dead")
        {
            //当たったら消える
            Destroy(this.gameObject);
        }
    }
}