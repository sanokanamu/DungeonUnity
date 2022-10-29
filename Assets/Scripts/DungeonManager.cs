using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    //  マップチップのプレハブ
    [SerializeField]
    private GameObject _mapParts = null;

    //  親オブジェクト
    [SerializeField]
    private Transform _parent = null;

    //  マップチップスプライト
    [SerializeField]
    private List<Sprite> _mapChipSprites = new List<Sprite>();

    private int[,,] _mapDataList = new int[,,]
    {
        {
        //   0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,0,1,1,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1},
            {1,0,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,0,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,0,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,0,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
        },
    };
    private List<List<List<int>>> _mapData = new List<List<List<int>>>()
    {
        new List<List<int>>()
        {
            new List<int>(){1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            new List<int>(){1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            new List<int>(){1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            new List<int>(){1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            new List<int>(){1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            new List<int>(){1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            new List<int>(){1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            new List<int>(){1,0,1,1,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1},
            new List<int>(){1,0,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1},
            new List<int>(){1,0,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1},
            new List<int>(){1,0,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1},
            new List<int>(){1,0,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1},
            new List<int>(){1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1},
            new List<int>(){1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            new List<int>(){1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            new List<int>(){1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            new List<int>(){1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            new List<int>(){1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            new List<int>(){1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            new List<int>(){1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
        },
    };

    [SerializeField, Header("プレイヤーをアタッチする")]

    private PlayerView _playerView = null;

    // Start is called before the first frame update
    void Start()
    {
        MapMake();
    }

    private void MapMake()
    {
        //  y を０から１９まで変化させる
        foreach (int y in Enumerable.Range(0, 20))
        {
            //  x を０から１９まで変化させる
            foreach (int x in Enumerable.Range(0, 20))
            {
                //  プレハブの実態をヒエラルキーに生成する
                GameObject gobj = Instantiate(_mapParts, _parent);
                //  表示座標を設定する
                gobj.transform.localPosition = new Vector3(-304 + x * 32, 304 - y * 32, 0);
                //  マップスプライトの設定
                // gobj.GetComponent<ChipView>().SetImage(_mapChipSprites[_mapData[0][y][x]]);
                gobj.GetComponent<ChipView>().SetImage(_mapChipSprites[_mapDataList[0, y, x]]);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _playerView.WalkAction(PlayerView.PlayerDirection.Right);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _playerView.WalkAction(PlayerView.PlayerDirection.Left);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            _playerView.WalkAction(PlayerView.PlayerDirection.Back);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            _playerView.WalkAction(PlayerView.PlayerDirection.Front);
        }
        else if(false == _playerView.IsWalking)
        {
            _playerView.SetAnimationState(PlayerView.PlayerMode.Idle);
        }
    }
}
