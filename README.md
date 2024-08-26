# Runtime GameObject Editor Values Provider

##### Easily test values in GameObject fields from regular C# classes without the need to recompile the project after each change.

### Overview

When working with Unity, you often need to adjust property values at runtime for testing purposes. However, if those values reside in scripts that are not inherited from `MonoBehaviour`, you can't tweak them directly in the editor. Iterating on values like animation duration, rect size, boolean flags, or sets of `GameObject` references typically requires editing the code, which triggers a recompilation and domain reload, slowing down your workflow.

![image](https://github.com/user-attachments/assets/399a3f07-4474-4a30-b73b-8c85d7c1c7d4)

This package provides a solution by allowing you to create a runtime `GameObject` with fields that can be dynamically modified via a simple static call, eliminating the need for repetitive recompilation and domain reloads.

### Key Features

- **Dynamic Value Testing**: Easily modify values at runtime without editing and recompiling your code.
- **Editor Integration**: The values are accessible and adjustable via the Unity editor, allowing you to quickly iterate on gameplay or visual elements.
- **Supports Multiple Types**: Includes support for common data types like `float`, `int`, `bool`, `string`, and Unity-specific types such as `Vector3` and `Color`.
- **Maintainability**: Keep your existing code structure without the need for making everything a `MonoBehaviour`.

### Use Case Example

Imagine you need to adjust the animation duration of a UI element dynamically while testing in the editor. Instead of changing the value in your code and waiting for recompilation and domain reload each time, you can simply adjust the value directly in the editor at runtime, test it, and find the right value efficiently.

### How It Works

1. **Static Method Call**: Create a runtime `GameObject` with fields that can be modified by making a simple static method call.
2. **No Recompilation**: You can tweak the values directly in the Unity editor, bypassing the need for code recompilation.
3. **Efficient Iteration**: This allows for rapid iteration on values without interrupting your workflow with recompilation or domain reloads.

### Installation

1. Install the repository with Unity Package Manager, or download/clone the repository.
2. Use the static method `RuntimeGameObjectProvider.GetValues()`, with an array of default values as a parameter, to access or set the test values in your non-MonoBehaviour scripts.

### Example Usage

Here's an example of how to use the `RuntimeGameObjectProvider` class:

```csharp
public class MyClass
{
    // Example of properties to set
    private float _animationDuration;
    private float _playerSpeed;

    public void Update() =>
        EditValuesFromEditor();

    private void EditValuesFromEditor()
    {
        // Get the value at runtime without recompilation
        var values = RuntimeGameObjectProvider.GetValue(new[] {0.5f, 10f}); // default values to start with
        _animationDuration = values[0]
        _playerSpeed = values[1];
    }
}
```

![image](https://github.com/user-attachments/assets/050627e2-ef2b-4828-8328-23453c770a01)

From here, you can edit the values in the editor and see how they impact code runtime without recompilation.

### Supported Types
- float
- int
- bool
- string
- Unity types like Vector3, Color, and GameObject

## Additionally Features
### MonoBehaviour Integration
Since the runtime GameObject is created with an attached `MonoBehaviour` script, you can leverage this `MonoBehaviour` to run coroutines and other Unity-specific features.

### Update Callback
The `RuntimeGameObjectProvider` provides a way to set an update callback using `RuntimeGameObjectProvider.SetCallback(Action action)`. This allows you to execute custom logic on each update frame.
```csharp
  public class MyClass
  {
    public void IncrementUpdate()
    {
      int[] values = RuntimeGameObjectProvider.GetValues(new[] {421});

      RuntimeGameObjectProvider.SetUpdate(() => {
        // Your update logic
        int value = values[0];
        value++;
        UnityEngine.Debug.Log($"{value}");
      });
    }
  }
```

### Future Enhancements
- Adding support for a single-value parameter, instead of an array.
- Adding support for additional Unity-specific types.
- Expanding the interface to handle custom serializable types.

### Contribution
Contributions are welcome! Feel free to fork the repository and submit a pull request if you have ideas for improving the package.
