using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionMarker : MonoBehaviour
{
    public float interactionDistance = 2f; // Расстояние, на котором игрок может взаимодействовать с предметом
    private GameObject player; // Ссылка на объект игрока
    public GameObject item;
    public GameObject keyObject;
    public Material highlightMaterial; // Материал с обводкой
    private Material originalMaterial; // Оригинальный материал объекта

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Получаем ссылку на игрока по тегу
        originalMaterial = GetComponent<Renderer>().material;
        if (keyObject != null)
        {
            keyObject.SetActive(GlobalState.Key);
        }
        //flagToOpenDoor = GetComponentInParent<FinalDoorInteraction>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        
        if (distanceToPlayer <= interactionDistance)
        {
            GetComponent<Renderer>().material = highlightMaterial;
            if (Input.GetKeyDown(KeyCode.F))
            {
                Interact();
            }
            // Активируем возможность взаимодействия, например, отображением иконки или подсказкой на экране
        }
        else
        {
            GetComponent<Renderer>().material = originalMaterial;
        }
    }

    public void Interact()
    {
        item.SetActive(false);
        if (item.tag == "coins")
        {
            GlobalState.Coin += 10;
            Debug.Log(GlobalState.Coin);
        }
        else if (item.tag == "key")
        {
            //flagToOpenDoor.key = true;
            GlobalState.Key = true;
            Debug.Log(GlobalState.Key);
            keyObject.SetActive(GlobalState.Key);
        }
        // Логика взаимодействия с предметом, например, подбор предмета
    }
}
