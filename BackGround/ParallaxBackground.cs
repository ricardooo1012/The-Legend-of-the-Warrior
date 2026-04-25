using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private Transform camTF;//相机对象

    //public Player player;//玩家对象
    private Transform playerTranform;

    private Vector3 lastPlayerPosition;//记录上一帧 的位置

    private float textureUnitSizeX;//获取图片长度
    private float textureUnitSizeY;//获取图片长度


    [SerializeField] Vector2 parallaxFactor;//滚动速度
    [SerializeField] private bool EnableX;
    [SerializeField] private bool EnableY;


    private void Awake()
    {
        //player = GetComponent<Player>();
        //playerTranform = player.transform;
        
    }


    void Start()
    {
        camTF = Camera.main.transform;//获取相机位置
        lastPlayerPosition = camTF.position;//初始化玩家位置
        Sprite sprit = this.GetComponent<SpriteRenderer>().sprite;
        textureUnitSizeX = sprit.texture.width / sprit.pixelsPerUnit;//前者为像素长度，后者是因为在unity中使用，是一个untiy的长度
        textureUnitSizeY = sprit.texture.height / sprit.pixelsPerUnit;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 distanceMoved = camTF.position - lastPlayerPosition;//计算相机移动的距离

        transform.position = transform.position + new Vector3(distanceMoved.x * parallaxFactor.x, distanceMoved.y * parallaxFactor.y);//根据设置的滚动速度移动背景

        lastPlayerPosition = camTF.position;//更新玩家位置
        //Debug.Log("position:" + player.transform);
        if (EnableX)
        {
            if (Mathf.Abs(camTF.position.x - transform.position.x) >= textureUnitSizeX)
            {
                float offSetX = camTF.position.x - transform.position.x;//人物可能一开始并不在地图背景正中间，所以需要设置偏移量
                transform.position = new Vector3(camTF.position.x + offSetX, transform.position.y);
            }
        }
        if (EnableY)
        {
            if (Mathf.Abs(camTF.position.y - transform.position.y) >= textureUnitSizeY)
            {
                float offSetY = camTF.position.y - transform.position.y;//人物可能一开始并不在地图背景正中间，所以需要设置偏移量
                transform.position = new Vector3(transform.position.y, camTF.position.y + offSetY);
            }
        }

    }
}
