using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AutoTIle : MonoBehaviour {

    public Tilemap tilemap;//引用的Tilemap
    public Tile baseTile;//使用的最基本的Tile，我这里是白色块，然后根据数据设置不同颜色生成不同Tile
    Tile[] arrTiles;//生成的Tile数组
    void Awake()
    {
        //ins = this;
    }
    void Start()
    {
        StartCoroutine(InitData());
    }
    IEnumerator InitData()
    {
        int levelW = 10;
        int levelH = 10;

        int colorCount = 6;
        arrTiles = new Tile[colorCount];
        for (int i = 0; i < colorCount; i++)
        {
            arrTiles[i] = ScriptableObject.CreateInstance<Tile>();//创建Tile，注意，要使用这种方式
            arrTiles[i].sprite = baseTile.sprite;
            arrTiles[i].color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
        }
        for (int i = 0; i < levelH; i++)
        {//这里就是设置每个Tile的信息了
            for (int j = 0; j < levelW; j++)
            {
                tilemap.SetTile(new Vector3Int(j, i, 0), arrTiles[Random.Range(0, arrTiles.Length)]);
            }
            yield return null;
        }

        while (true)
        {
            yield return new WaitForSeconds(2);
            // int colorIdx = Random.Range(0, colorCount);//前面这个是随机将某个块的颜色改变，然后让Tilemap更新，主要用来更新Tile的变化
            // arrTiles[colorIdx].color = new Color(Random.Range(0f, 1f), Random.Range(0f,1f), Random.Range(0f, 1f), 1);
            // tilemap.RefreshAllTiles();

            Color c = tilemap.color;//这里是改变Tilemap的颜色，尝试是否可以整体变色
            c.a -= Time.deltaTime;
            tilemap.color = c;
        }
    }

}
