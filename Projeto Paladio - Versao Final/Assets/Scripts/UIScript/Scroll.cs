using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    [SerializeField] private Transform textPosition;
    private Vector3 offset;

    [SerializeField] private Transform limitePraCima;
    [SerializeField] private Transform limitePraBaixo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    offset = textPosition.position - touchPosition;
                    break;

                case TouchPhase.Moved:

                    if (textPosition.position.y <= limitePraCima.position.y && textPosition.position.y >= limitePraBaixo.position.y)
                        textPosition.position = new Vector3 (textPosition.position.x, touchPosition.y + offset.y, textPosition.position.z);
                    break;
            }
        }

        if (textPosition.position.y > limitePraCima.position.y)
            textPosition.position = new Vector3(textPosition.position.x, limitePraCima.position.y, textPosition.position.z);

        if (textPosition.position.y < limitePraBaixo.position.y)
            textPosition.position = new Vector3(textPosition.position.x, limitePraBaixo.position.y, textPosition.position.z);
    }
}
