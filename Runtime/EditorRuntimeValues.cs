using System;
using UnityEngine;

namespace editor_values_provider.Runtime
{
  public static class EditorRuntimeValues
  {
    private static TestValuesProvider _testValuesProvider;

    public static void SetUpdate(Action action)
    {
      CreateGameObject();
      _testValuesProvider.Action = action;
    }

    private static void CreateGameObject()
    {
      if (_testValuesProvider == null) {
        _testValuesProvider = new GameObject(nameof(TestValuesProvider)).AddComponent<TestValuesProvider>();
      }
    }

    public static T[] GetValues<T>(T[] defaultValues)
    {
      CreateGameObject();

      return GetStoredValues<T>();

      T[] GetStoredValues<U>()
      {
        if (typeof(U) == typeof(float)) {
          if (_testValuesProvider.FloatValues.Length == 0) {
            _testValuesProvider.FloatValues = defaultValues as float[];
          }

          return _testValuesProvider.FloatValues as T[];
        }

        if (typeof(U) == typeof(int)) {
          if (_testValuesProvider.IntValues.Length == 0) {
            _testValuesProvider.IntValues = defaultValues as int[];
          }

          return _testValuesProvider.IntValues as T[];
        }

        if (typeof(U) == typeof(string)) {
          if (_testValuesProvider.StringValues.Length == 0) {
            _testValuesProvider.StringValues = defaultValues as string[];
          }

          return _testValuesProvider.StringValues as T[];
        }

        if (typeof(T) == typeof(bool)) {
          if (_testValuesProvider.BoolValues.Length == 0) {
            _testValuesProvider.BoolValues = defaultValues as bool[];
          }

          return _testValuesProvider.BoolValues as T[];
        }

        if (typeof(T) == typeof(Vector3)) {
          if (_testValuesProvider.Vector3Values.Length == 0) {
            _testValuesProvider.Vector3Values = defaultValues as Vector3[];
          }

          return _testValuesProvider.Vector3Values as T[];
        }

        if (typeof(T) == typeof(Vector2)) {
          if (_testValuesProvider.Vector2Values.Length == 0) {
            _testValuesProvider.Vector2Values = defaultValues as Vector2[];
          }

          return _testValuesProvider.Vector2Values as T[];
        }

        if (typeof(T) == typeof(Color)) {
          if (_testValuesProvider.ColorValues.Length == 0) {
            _testValuesProvider.ColorValues = defaultValues as Color[];
          }

          return _testValuesProvider.ColorValues as T[];
        }

        if (typeof(T) == typeof(GameObject)) {
          if (_testValuesProvider.GameObjectValues.Length == 0) {
            _testValuesProvider.GameObjectValues = defaultValues as GameObject[];
          }

          return _testValuesProvider.GameObjectValues as T[];
        }

        throw new NotSupportedException($"Type {typeof(U)} is not supported");
      }
    }
  }
}