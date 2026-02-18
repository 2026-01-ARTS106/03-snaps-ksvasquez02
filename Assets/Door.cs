using UnityEngine;
using UnityEngine.Audio;

public class Door : MonoBehaviour
{
    public bool open = false;
    public bool animating = false;
    public float speed = 90f;
    public float target = 90f;
    public float currentAngle = 0f;
    public float startingAngle = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingAngle = transform.GetChild(0).eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (animating && !open)
        {
            currentAngle = currentAngle + speed * Time.deltaTime;
            if (Mathf.Abs(currentAngle) >= Mathf.Abs(target) && Mathf.Sign(currentAngle) == Mathf.Sign(target))
            {
                animating = false;
                open = true;
                currentAngle = target;
            }

            foreach (Transform child in transform)
            {
                child.eulerAngles = new Vector3(0, startingAngle + currentAngle * Mathf.Sign(child.localScale.x), 0);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Touch!");
        animating = true;
    }

    void AnimateOpen(bool open)
    {
        
    }
}
