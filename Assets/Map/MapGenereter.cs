using UnityEngine;
using System.Collections.Generic;
public class SystemManager : MonoBehaviour
{

    static int MapWidth = 50;
    static int MapHeight = 50;

    int[,] Map;

    const int wall = 9;
    const int road = 0;
    const int door = 1; // ドアの定数を追加

    public GameObject WallObject;
    public GameObject DoorObject; // ドアオブジェクトを追加
    public GameObject DustCube;

    const int roomMinHeight = 5;
    const int roomMaxHeight = 10;

    const int roomMinWidth = 5;
    const int roomMaxWidth = 10;

    const int RoomCountMin = 10;
    const int RoomCountMax = 15;

    const int meetPointCount = 1;

    // ドア生成の設定
    const int doorPlacementChance = 101; // ドアを設置する確率（パーセント）
    const int minRoadLengthForDoor = 1; // ドアを設置するのに必要な最小道路長

    private List<List<Vector2Int>> roomList = new List<List<Vector2Int>>();

    void Start()
    {
        ResetMapData();
        CreateSpaceData();
        PlaceDoorsOnRoads(); // ドアを道に配置
        CreateDangeon();
    }

    void Update()
    {

    }

    /// <summary>
    /// Mapの二次元配列の初期化
    /// </summary>
    private void ResetMapData()
    {
        Map = new int[MapHeight, MapWidth];
        for (int i = 0; i < MapHeight; i++)
        {
            for (int j = 0; j < MapWidth; j++)
            {
                Map[i, j] = wall;
            }
        }
    }

    /// <summary>
    /// 空白部分のデータを変更
    /// </summary>
    private void CreateSpaceData()
    {
        int roomCount = Random.Range(RoomCountMin, RoomCountMax);

        int[] meetPointsX = new int[meetPointCount];
        int[] meetPointsY = new int[meetPointCount];
        for (int i = 0; i < meetPointsX.Length; i++)
        {
            meetPointsX[i] = Random.Range(MapWidth / 4, MapWidth * 3 / 4);
            meetPointsY[i] = Random.Range(MapHeight / 4, MapHeight * 3 / 4);
            Map[meetPointsY[i], meetPointsX[i]] = road;
        }

        for (int i = 0; i < roomCount; i++)
        {
            int roomHeight = Random.Range(roomMinHeight, roomMaxHeight);
            int roomWidth = Random.Range(roomMinWidth, roomMaxWidth);
            int roomPointX = Random.Range(2, MapWidth - roomMaxWidth - 2);
            int roomPointY = Random.Range(2, MapWidth - roomMaxWidth - 2);

            int roadStartPointX = Random.Range(roomPointX, roomPointX + roomWidth);
            int roadStartPointY = Random.Range(roomPointY, roomPointY + roomHeight);

            bool isRoad = CreateRoomData(roomHeight, roomWidth, roomPointX, roomPointY);

            if (isRoad == false)
            {
                CreateRoadData(roadStartPointX, roadStartPointY, meetPointsX[Random.Range(0, 0)], meetPointsY[Random.Range(0, 0)]);
            }
        }
    }

    /// <summary>
    /// 道にドアを配置
    /// </summary>
    private void PlaceDoorsOnRoads()
    {
        // 横方向の道路をチェック
        for (int i = 1; i < MapHeight - 1; i++)
        {
            int roadLength = 0;
            int roadStart = -1;

            for (int j = 0; j < MapWidth; j++)
            {
                if (Map[i, j] == road)
                {
                    if (roadStart == -1) roadStart = j;
                    roadLength++;
                }
                else
                {
                    if (roadLength >= minRoadLengthForDoor && Random.Range(0, 100) < doorPlacementChance)
                    {
                        // 道路の中央付近にドアを配置
                        int doorPos = roadStart + roadLength / 2;
                        if (IsValidDoorPosition(i, doorPos, true))
                        {
                            Map[i, doorPos] = door;
                        }
                    }
                    roadLength = 0;
                    roadStart = -1;
                }
            }

            // 行の最後でも確認
            if (roadLength >= minRoadLengthForDoor && Random.Range(0, 100) < doorPlacementChance)
            {
                int doorPos = roadStart + roadLength / 2;
                if (IsValidDoorPosition(i, doorPos, true))
                {
                    Map[i, doorPos] = door;
                }
            }
        }

        // 縦方向の道路をチェック
        for (int j = 1; j < MapWidth - 1; j++)
        {
            int roadLength = 0;
            int roadStart = -1;

            for (int i = 0; i < MapHeight; i++)
            {
                if (Map[i, j] == road)
                {
                    if (roadStart == -1) roadStart = i;
                    roadLength++;
                }
                else
                {
                    if (roadLength >= minRoadLengthForDoor && Random.Range(0, 100) < doorPlacementChance)
                    {
                        // 道路の中央付近にドアを配置
                        int doorPos = roadStart + roadLength / 2;
                        if (IsValidDoorPosition(doorPos, j, false))
                        {
                            Map[doorPos, j] = door;
                        }
                    }
                    roadLength = 0;
                    roadStart = -1;
                }
            }

            // 列の最後でも確認
            if (roadLength >= minRoadLengthForDoor && Random.Range(0, 100) < doorPlacementChance)
            {
                int doorPos = roadStart + roadLength / 2;
                if (IsValidDoorPosition(doorPos, j, false))
                {
                    Map[doorPos, j] = door;
                }
            }
        }
    }

    /// <summary>
    /// ドアを配置できる有効な位置かチェック
    /// </summary>
    /// <param name="z">Z座標（マップ配列のi）</param>
    /// <param name="x">X座標（マップ配列のj）</param>
    /// <param name="isXDirection">X方向の道路かどうか</param>
    /// <returns></returns>
    private bool IsValidDoorPosition(int z, int x, bool isXDirection)
    {
        if (z < 1 || z >= MapHeight - 1 || x < 1 || x >= MapWidth - 1) return false;

        // 既にドアが設置されていないかチェック
        if (Map[z, x] == door) return false;

        if (isXDirection)
        {
            // X方向の道路の場合、Z方向の前後が壁であることを確認
            return Map[z - 1, x] == wall && Map[z + 1, x] == wall;
        }
        else
        {
            // Z方向の道路の場合、X方向の左右が壁であることを確認
            return Map[z, x - 1] == wall && Map[z, x + 1] == wall;
        }
    }

    /// <summary>
    /// 部屋データを生成。すでに部屋がある場合はtrueを返し、道を作らないようにする
    /// </summary>
    /// <param name="roomHeight">部屋の高さ</param>
    /// <param name="roomWidth">部屋の横幅</param>
    /// <param name="roomPointX">部屋の始点(x)</param>
    /// <param name="roomPointY">部屋の始点(y)</param>
    /// <returns></returns>
    private bool CreateRoomData(int roomHeight, int roomWidth, int roomPointX, int roomPointY)
    {
        bool isRoad = false;
        List<Vector2Int> currentRoom = new List<Vector2Int>();

        for (int i = 0; i < roomHeight; i++)
        {
            for (int j = 0; j < roomWidth; j++)
            {
                int x = roomPointX + j;
                int y = roomPointY + i;

                if (Map[y, x] == road)
                {
                    isRoad = true;
                }
                else
                {
                    Map[y, x] = road;
                }

                currentRoom.Add(new Vector2Int(x, y));
            }
        }

        // 部屋として保存
        if (currentRoom.Count > 0)
        {
            roomList.Add(currentRoom);
        }

        return isRoad;
    }


    /// <summary>
    /// 道データを生成
    /// </summary>
    /// <param name="roadStartPointX"></param>
    /// <param name="roadStartPointY"></param>
    /// <param name="meetPointX"></param>
    /// <param name="meetPointY"></param>
    private void CreateRoadData(int roadStartPointX, int roadStartPointY, int meetPointX, int meetPointY)
    {
        bool isRight;
        if (roadStartPointX > meetPointX)
        {
            isRight = true;
        }
        else
        {
            isRight = false;
        }
        bool isUnder;
        if (roadStartPointY > meetPointY)
        {
            isUnder = false;
        }
        else
        {
            isUnder = true;
        }

        if (Random.Range(0, 2) == 0)
        {
            while (roadStartPointX != meetPointX)
            {
                Map[roadStartPointY, roadStartPointX] = road;
                if (isRight == true)
                {
                    roadStartPointX--;
                }
                else
                {
                    roadStartPointX++;
                }
            }

            while (roadStartPointY != meetPointY)
            {
                Map[roadStartPointY, roadStartPointX] = road;
                if (isUnder == true)
                {
                    roadStartPointY++;
                }
                else
                {
                    roadStartPointY--;
                }
            }
        }
        else
        {
            while (roadStartPointY != meetPointY)
            {
                Map[roadStartPointY, roadStartPointX] = road;
                if (isUnder == true)
                {
                    roadStartPointY++;
                }
                else
                {
                    roadStartPointY--;
                }
            }

            while (roadStartPointX != meetPointX)
            {
                Map[roadStartPointY, roadStartPointX] = road;
                if (isRight == true)
                {
                    roadStartPointX--;
                }
                else
                {
                    roadStartPointX++;
                }
            }
        }
    }

    /// <summary>
    /// マップデータをもとにダンジョンを生成
    /// </summary>
    private void CreateDangeon()
    {
        for (int i = 0; i < MapHeight; i++)
        {
            for (int j = 0; j < MapWidth; j++)
            {
                if (Map[i, j] == wall)
                {
                    Instantiate(WallObject, new Vector3(j - MapWidth / 2, 0, i - MapHeight / 2), Quaternion.identity);
                }
                else if (Map[i, j] == door)
                {
                    Instantiate(DoorObject, new Vector3(j - MapWidth / 2, 0, i - MapHeight / 2), Quaternion.identity);
                }
            }
        }

        // 各部屋に DustCube を配置
        foreach (var room in roomList)
        {
            if (room.Count > 0)
            {
                // 部屋の中からランダムな座標を選ぶ
                Vector2Int pos = room[Random.Range(0, room.Count)];
                Instantiate(DustCube, new Vector3(pos.x - MapWidth / 2, 0, pos.y - MapHeight / 2), Quaternion.identity);
            }
        }
    }

}