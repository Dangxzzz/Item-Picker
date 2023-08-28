using System;
using ItemPicker.Game.Items;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ItemPicker.Services
{
    public class SpawnService : MonoBehaviour
    {
        #region Variables

        [Header("Configs")]
        [SerializeField] private float _spawnRate = 2f;
        [SerializeField] private float _increaseSpawnRate;
        [SerializeField] private float _minSpawnRate;
        [SerializeField] private ItemSpawnData[] _items;
        [SerializeField] private float _currentGravityScale;
        [SerializeField] private float _increaseGravityScale;
        [SerializeField] private float _maxGravityScale;
        private readonly float _leftLimit = -8.5f;
        private float _nextSpawn;
        private float _randX;

        private Rigidbody2D _rg;
        private readonly float _rightLimit = 8.5f;
        private Vector2 _whereToSpawn;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            Item.OnCreated += OnItemCreated;
        }

        private void Start()
        {
            InvokeRepeating("IncreaseSpawnRate", 1f, 20f);
            InvokeRepeating("IncreaseGravityScale", 1f, 20f);
        }

        private void Update()
        {
            CreateItem();
        }

        private void OnDestroy()
        {
            Item.OnCreated -= OnItemCreated;
        }

        private void OnValidate()
        {
            if (_items == null)
            {
                return;
            }

            foreach (ItemSpawnData itemSpawnData in _items)
            {
                itemSpawnData.OnValidate();
            }
        }

        #endregion

        #region Private methods

        private void CreateItem()
        {
            if (_items == null || _items.Length == 0)
            {
                return;
            }

            if (Time.time > _nextSpawn)
            {
                _nextSpawn = Time.time + _spawnRate;

                _randX = Random.Range(_leftLimit, _rightLimit);
                _whereToSpawn = new Vector2(_randX, transform.position.y);
                InstantiateItemPrebab(_whereToSpawn);
            }
        }

        private void IncreaseGravityScale()
        {
            if (_currentGravityScale >= _maxGravityScale)
            {
                return;
            }
            _currentGravityScale += _increaseGravityScale;
        }

        private void IncreaseSpawnRate()
        {
            if (_spawnRate <= _minSpawnRate)
            {
                return;
            }
            _spawnRate += _increaseSpawnRate;
        }

        private void InstantiateItemPrebab(Vector2 position)
        {
            int weightSum = 0;
            foreach (ItemSpawnData spawnData in _items)
            {
                weightSum += spawnData.SpawnWeight;
            }

            int randomWeight = Random.Range(0, weightSum + 1);
            int selectedWeight = 0;

            for (int i = 0; i < _items.Length; i++)
            {
                ItemSpawnData spawnData = _items[i];
                selectedWeight += spawnData.SpawnWeight;

                if (selectedWeight >= randomWeight)
                {
                    Instantiate(spawnData.ItemPrefab, position, Quaternion.identity);

                    return;
                }
            }
        }

        private void OnItemCreated(Item item)
        {
            item.ItemRigidBody.gravityScale = _currentGravityScale;
        }

        private void SpawnRate()
        {
            _spawnRate += _increaseGravityScale;
        }

        #endregion

        #region Local data

        [Serializable]
        private class ItemSpawnData
        {
            #region Variables

            public Item ItemPrefab;
            [HideInInspector]
            public string Name;
            public int SpawnWeight;

            #endregion

            #region Public methods

            public void OnValidate()
            {
                if (ItemPrefab == null)
                {
                    Name = "Empty";
                }
                else
                {
                    Name = $"{ItemPrefab.name}:{SpawnWeight}";
                }
            }

            #endregion
        }

        #endregion
    }
}