
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("移動速度"), Range(0, 50)]
    public float speed = 3;
    [Header("停止距離"), Range(0, 50)]
    public float stopDistance = 5f;
    [Header("攻擊冷卻"), Range(0, 50)]
    public float cd = 2f;



    private Transform player;
    private NavMeshAgent nav;
    private Animator ani;

    private float timer;

    private void Awake()
    {
        ///取得身上的元件(代理器)
        nav = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        ///尋找其他遊戲物件("物件名稱").變形元件
        player = GameObject.Find("SantaClaus").transform;

        nav.speed = speed;
        nav.stoppingDistance = stopDistance;
    }

    private void Update()
    {
        track();
        Attack();
    }

    private void Attack()
    {
        if (nav.remainingDistance < stopDistance)
        {
            timer += Time.deltaTime;

            Vector3 pos = player.position;

            pos.y = transform.position.y;

            transform.LookAt(pos);

            if (timer >= cd)
            { 
                ani.SetTrigger("攻擊");

                timer = 0;
            }
        }
    }


    /// <summary>
    /// 追蹤
    /// </summary>
    private void track()
    {
        ///代理器.設定目的地(玩家座標)
        nav.SetDestination(player.position);

        ///print("剩餘距離:" + nav.remainingDistance);
        ani.SetBool("跑步", nav.remainingDistance > stopDistance);

    }
}
