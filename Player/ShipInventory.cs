using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShipInventory : MonoBehaviour
{
    public static ShipInventory Instance { get; private set; }

    [Header("UI Game Objects")]
    [SerializeField] private GameObject shipInventoryUI;
    [SerializeField] private TextMeshProUGUI totalAmount;
    [SerializeField] private TextMeshProUGUI goldAmount;
    [SerializeField] private TextMeshProUGUI foodAmount;
    [SerializeField] private TextMeshProUGUI luxuriesAmount;
    [SerializeField] private TextMeshProUGUI goodsAmount;
    [SerializeField] private TextMeshProUGUI spiceAmount;
    [SerializeField] private TextMeshProUGUI sugarAmount;
    [SerializeField] private TextMeshProUGUI cannonAmount;

    [Header("Ship Cargo Capacity")]
    [SerializeField] private int maxCargoCapacity;
    [SerializeField] private int currentCargoCapacity;
    [SerializeField] private int spaceLeftinCargo;

    [Header("Inventory Goods and Gold")]
    [SerializeField] private int gold;
    [SerializeField] private int food;
    [SerializeField] private int luxuries;
    [SerializeField] private int goods;
    [SerializeField] private int spice;
    [SerializeField] private int sugar;
    [SerializeField] private int cannon;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // TO DO: SET maxCargoCapacity ACCORDING TO THE TYPE OF SHIP THE PLAYER IS USING
        maxCargoCapacity = 1200;
        currentCargoCapacity = 0;
        spaceLeftinCargo = maxCargoCapacity - currentCargoCapacity;

        gold = 4000;
        food = 40;
        luxuries = 0;
        goods = 0;
        spice = 0;
        sugar = 0;
        cannon = 12;

        DisableShipInventoryUI();
    }

    // TO DO: FIND OUT HOW TO NOT LET THE CURRENT CAPACITY EXCEED THE MAX CAPACITY

    private void UpdateShipInventoryUI()
    {
        UpdateCurrentCargoCapacity();

        //TO DO: UPDATE TOTAL AMOUNT ACCORDING TO THE SHIP
        totalAmount.text = $"{currentCargoCapacity} / {maxCargoCapacity}";
        goldAmount.text = gold.ToString();
        foodAmount.text = food.ToString();
        luxuriesAmount.text = luxuries.ToString();
        goodsAmount.text = goods.ToString();
        spiceAmount.text = spice.ToString();
        sugarAmount.text = sugar.ToString();
        cannonAmount.text = cannon.ToString();
    }

    private void UpdateCurrentCargoCapacity()
    {
        currentCargoCapacity = 0;
        currentCargoCapacity += food;
        currentCargoCapacity += luxuries;
        currentCargoCapacity += goods;
        currentCargoCapacity += spice;
        currentCargoCapacity += sugar;
        currentCargoCapacity += cannon;
    }

    public void EnableShipInventoryUI()
    {
        shipInventoryUI.SetActive(true);
        UpdateShipInventoryUI();

    }
    public void DisableShipInventoryUI()
    {
        shipInventoryUI.SetActive(false);
    }
}
