using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    public GameObject spikeLeft;
    public GameObject spikeMid;
    public GameObject spikeRight;

    public void OnRectTransformDimensionsChange()
    {
        foreach (Transform child in this.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        float yMidSpike = spikeMid.GetComponent<RectTransform>().rect.width;
        int spikeCount = Mathf.FloorToInt((this.GetComponent<RectTransform>().rect.width - 300) / yMidSpike);
        float spikeOffset = 350 / 44;

        Instantiate(spikeLeft, new Vector3(-spikeOffset - Mathf.FloorToInt((spikeCount + 1) * yMidSpike / 2), 0, 0), Quaternion.identity).transform.SetParent(this.transform, false);
        for (int i = 0; i < spikeCount; i++)
        {
            Instantiate(spikeMid, new Vector3(i * yMidSpike - Mathf.FloorToInt((spikeCount - 1) * yMidSpike / 2), 0, 1), Quaternion.identity).transform.SetParent(this.transform, false);
        }
        Instantiate(spikeRight, new Vector3(spikeOffset + Mathf.FloorToInt((spikeCount + 1) * yMidSpike / 2), 0, 0), Quaternion.identity).transform.SetParent(this.transform, false);
    }
}
