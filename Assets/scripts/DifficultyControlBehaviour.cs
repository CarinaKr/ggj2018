using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DifficultyControlBehaviour : MonoBehaviour {

    private DOTweenPath dOTweenPath;
    private float rate;
    public float cycleCount;

    public void changeSpeedBy(DOTweenPath dOTweenPath, float rate){
        this.dOTweenPath = dOTweenPath;
        this.rate = rate;
        StartCoroutine("speedUp");
    }

    // Will add a Satelite behind the infoTrain
    public void addSatelite()
    {
        Transform infoTrainTrans = GameControlBehaviour.instance.infoTrain.transform;
        GameObject satelite = Instantiate(GameControlBehaviour.instance.satelitePrefab,infoTrainTrans);
        satelite.transform.localPosition = new Vector3(0f, 0f, -infoTrainTrans.childCount *2);

    }

    public void destroyLastSatelite()
    {
        Transform infoTrainTrans = GameControlBehaviour.instance.infoTrain.transform;
        Destroy(infoTrainTrans.GetChild(infoTrainTrans.childCount-1).gameObject);
    }

    public IEnumerator speedUp()
    {
        //DOTweenPath path = GetComponent<DOTweenPath>();
        Tween t = dOTweenPath.GetTween();
        for (int i = 0; i < 10; i++)
        {
            // Change the timeScale to 2x
            t.timeScale += rate;
            yield return new WaitForSeconds(1f);
        }
    }
}
