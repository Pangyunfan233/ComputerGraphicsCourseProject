using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Disov : MonoBehaviour
{
    public GameObject Root;

    public float DissolveTime = 3f;

    private MeshRenderer[] renderers;
    private bool isDissolving = false;

    void Start()
    {
        renderers = Root.GetComponentsInChildren<MeshRenderer>();
    }

    void Update()
    {
        //if (Keyboard.current.enterKey.wasReleasedThisFrame && !isDissolving)
            // IF DIED
      //  {
         //   StartCoroutine(Dissolve());
        //}
    }

    private IEnumerator Dissolve()
    {
        isDissolving = true;
        SetDissolveRate(0);

        float time = 0;
        while (time < DissolveTime)
        {
            time += Time.deltaTime;
            float rate = Mathf.Clamp01(time / DissolveTime);
            SetDissolveRate(rate);
            yield return null;
        }

        SetDissolveRate(1);
        isDissolving = false;
    }

    private void SetDissolveRate(float value)
    {
        int shaderId = Shader.PropertyToID("_ClipRate");

        foreach (MeshRenderer meshRenderer in renderers)
        {
            foreach (Material mat in meshRenderer.materials)
            {
                mat.SetFloat(shaderId, value);
            }
        }
    }

    private void OnTriggerEnter(Collider other) 
    { 
        if (other.CompareTag("Goal") && isDissolving== false) 
        { Debug.Log("Player reached the goal!");
            StartCoroutine(Dissolve());
            isDissolving = true;
        } 
    }
}


