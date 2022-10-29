using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    //  アニメーションに関連あるプレイヤーの状態
    public enum PlayerMode
    {
        Idle = 0,
        RightWalk = 1,
        FrontWalk = 2,
        LeftWalk = 3,
        BackWalk = 4
    }

    public enum PlayerDirection
    {
        None = 0,
        Right = 1,
        Front = 2,
        Left = 3,
        Back = 4
    }
    //  プレイヤーの状態
    private PlayerMode _playerMode = PlayerMode.Idle;

    [SerializeField]
    private Animator _animator = null;

    private Vector3 _ofp = Vector3.zero;

    private Dictionary<PlayerDirection, Vector3> _playerWalkAddLists = new Dictionary<PlayerDirection, Vector3>()
    {
        {PlayerDirection.None , Vector3.zero},
        {PlayerDirection.Right , new Vector3(x:1f, y:0f, z:0f)},
        {PlayerDirection.Front , new Vector3(x:0f, y:-1f, z:0f)},
        {PlayerDirection.Left , new Vector3(x:-1f, y:0f, z:0f)},
        {PlayerDirection.Back , new Vector3(x:0f, y:1f, z:0f)},
    };
    // 移動速度
    [SerializeField]
    private float _walkSpeed = 1f;

    private bool _isWalking = false;
    public bool IsWalking => _isWalking;

    public Vector2 PlayerPos { get; private set; } = new Vector2(x: 1, y: 1);

    private static readonly int PlayerAnimStat = Animator.StringToHash("PlayerAnimStat");

    private static readonly Vector3 PlayerInitialposition = new Vector3(x: -272f, y: 272f, z: 0f);

    private void Awake()
    {
        transform.localPosition = PlayerInitialposition;
    }

    /// <summary>
    /// 外部よりアニメーションのモードを切り替える
    /// </summary>
    /// <param name="playerMode"></param>

    // Start is called before the first frame update
    public void SetAnimationState(PlayerMode playerMode)
    {
        _animator.SetInteger("PlayerAnimStat", (int)playerMode);
    }

    /// <summary>
    /// 移動処理
    /// </summary>
    public void WalkAction(PlayerDirection playerDirection)
    {
        //すでに移動中ならば何もしない
        if (_isWalking) return;
        _isWalking = true;
        //移動開始
        StartCoroutine(Walking(playerDirection));
    }

    /// <summary>
    /// 移動のルーチン
    /// </summary>
    /// <param name="playerDirection"></param>
    /// <returns></returns>
    private IEnumerator Walking(PlayerDirection playerDirection)
    {
        //移動前の座標
        Vector3 orgPos = transform.localPosition;
        _ofp = Vector3.zero;
        SetAnimationState((PlayerMode)playerDirection);
        while (true)
        {
            //加算する座標を計算する
            _ofp += _playerWalkAddLists[playerDirection] * _walkSpeed;
            // 移動範囲が1ブロックを超えたら、1ブロック分に直す
            if (_ofp.magnitude > 32f)
            {
                _ofp = _playerWalkAddLists[playerDirection] * 32;
                //座標を更新する
                transform.localPosition = orgPos + _ofp;
                //ループを抜ける
                break;
            }
            //座標を更新する
            transform.localPosition = orgPos + _ofp;

            //次の updote まで待つ
            yield return null;
        }
        _isWalking = false;
    }

}
