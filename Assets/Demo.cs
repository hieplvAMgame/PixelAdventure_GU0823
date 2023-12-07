using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

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
    int count = 0;
    int target;
    Vector3 nextPos;
    public void MoveFollowList(List<Transform> list, float duration)
    {
        StartCoroutine(CoMoveFollowList(list, duration));
    }
    IEnumerator CoMoveFollowList(List<Transform> list, float duration)
    {
        transform.position = list[id].position;
        while (count < list.Count)
        {
            count++;
            target = id + count;
            if (target >= list.Count)
                target = id + count - list.Count;
            nextPos = list[target].position;
            transform.DOMove(nextPos, duration);
            yield return new WaitForSeconds(duration);
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
