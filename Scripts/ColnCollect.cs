using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColnCollect : MonoBehaviour
{
    public float speed;
    public Transform target;
    public GameObject Coinprefab;


    // Start is called before the first frame update
    void Start()
    {
        /*if(cam == null)
        {
            cam = Camera.main;
        }*/
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void CoinMove(Vector3 _inital)
    {
        //Vector3 initalPos = cam.ScreenToWorldPoint(new Vector3(_inital.x, _inital.y, cam.transform.position.z * -1));
        //Vector3 targetPos = cam.ScreenToWorldPoint(new Vector3(target.position.x, target.position.y, cam.transform.position.z * -1));
        //GameObject _coin = Instantiate(Coinprefab, transform);

       
        StartCoroutine(MoveCoins(Coinprefab.transform, _inital, target.transform.position));
    }
    IEnumerator MoveCoins(Transform obj,Vector3 startPos,Vector3 endPos)
    {
        Coinprefab.SetActive(true);
        float time = 0;
        endPos.x += 1;
        endPos.y += 1;
        while (time < 1)
        {
           
            time += speed * Time.deltaTime;
            obj.position = Vector2.Lerp(startPos, endPos, time);

            yield return new WaitForEndOfFrame();
            
        }
        Coinprefab.SetActive(false);
        yield return new WaitForSeconds(0f);
        Destroy(gameObject);
    }
}
