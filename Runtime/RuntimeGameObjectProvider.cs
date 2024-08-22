using System;
using UnityEngine;

namespace editor_values_provider
{
  public static class RuntimeGameObjectProvider
  {
    private static RuntimeGameObject _runtimeGameObject;

    public static MonoBehaviour MonoBehaviour =>
      _runtimeGameObject;

    public static T[] GetValues<T>(T[] defaultValues)
    {
      CreateGameObject();

      return GetStoredValues<T>();

      T[] GetStoredValues<U>()
      {
        if (typeof(U) == typeof(float)) {
          if (_runtimeGameObject.FloatValues.Length == 0) {
            _runtimeGameObject.FloatValues = defaultValues as float[];
          }

          return _runtimeGameObject.FloatValues as T[];
        }

        if (typeof(U) == typeof(int)) {
          if (_runtimeGameObject.IntValues.Length == 0) {
            _runtimeGameObject.IntValues = defaultValues as int[];
          }

          return _runtimeGameObject.IntValues as T[];
        }

        if (typeof(U) == typeof(string)) {
          if (_runtimeGameObject.StringValues.Length == 0) {
            _runtimeGameObject.StringValues = defaultValues as string[];
          }

          return _runtimeGameObject.StringValues as T[];
        }

        if (typeof(T) == typeof(bool)) {
          if (_runtimeGameObject.BoolValues.Length == 0) {
            _runtimeGameObject.BoolValues = defaultValues as bool[];
          }

          return _runtimeGameObject.BoolValues as T[];
        }

        if (typeof(T) == typeof(Vector3)) {
          if (_runtimeGameObject.Vector3Values.Length == 0) {
            _runtimeGameObject.Vector3Values = defaultValues as Vector3[];
          }

          return _runtimeGameObject.Vector3Values as T[];
        }

        if (typeof(T) == typeof(Vector2)) {
          if (_runtimeGameObject.Vector2Values.Length == 0) {
            _runtimeGameObject.Vector2Values = defaultValues as Vector2[];
          }

          return _runtimeGameObject.Vector2Values as T[];
        }

        if (typeof(T) == typeof(Color)) {
          if (_runtimeGameObject.ColorValues.Length == 0) {
            _runtimeGameObject.ColorValues = defaultValues as Color[];
          }

          return _runtimeGameObject.ColorValues as T[];
        }

        if (typeof(T) == typeof(GameObject)) {
          if (_runtimeGameObject.GameObjectValues.Length == 0) {
            _runtimeGameObject.GameObjectValues = defaultValues as GameObject[];
          }

          return _runtimeGameObject.GameObjectValues as T[];
        }

        throw new NotSupportedException($"Type {typeof(U)} is not supported");
      }
    }

    private static void CreateGameObject()
    {
      if (_runtimeGameObject == null) {
        _runtimeGameObject = new GameObject(nameof(RuntimeGameObject)).AddComponent<RuntimeGameObject>();
      }
    }

    public static void SetUpdate(Action action)
    {
      CreateGameObject();
      _runtimeGameObject.Action = action;
    }

    public static void ResetUpdate()
    {
      CreateGameObject();
      _runtimeGameObject.Action = () => { };
    }
  }
}