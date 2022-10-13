using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour, IPointerDownHandler {

    //костыль исправь потом на клик вмесато нажатия
    public void OnPointerDown(PointerEventData eventData)
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
