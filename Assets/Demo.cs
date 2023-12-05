using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Demo : MonoBehaviour
{
    public int id;
    [SerializeField] SpriteRenderer render;
    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    public void MovePos(Transform target, float duration)
    {
        transform.DOMove(target.position, duration);
    }
    public void MoveFollowList(List<Transform> listTrans, float duration)
    {
        transform.position = listTrans[id].position;
        int target = 0;
        for (int i = 0; i < listTrans.Count; i++)
        {
            target = id + i + 1;
            if (target >= listTrans.Count)
                target -= listTrans.Count;
            transform.DOMove(listTrans[target].position, duration);
            this.WaitForSeconds(duration, () => { });
        }
    }
    public void ChangeColor(Color color)
    {
        render.color = color;
    }
}
// Tao 4 diem la 4 goc cua 1 hinh vuong. O moi dinh co 1 game object ( thay doi mau cho phan biet).
// Dung dotween di chuyen cac doi tuong theo vong tron, moi di chuyen mat 2s ( tong cong 8s).
// A->B, B->C, C->D, D->A va lap lai
// Khi ket thuc, doi mau tat ca game Object thanh mau do
