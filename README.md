# C# Reference Semantics with Value Types
Reference Semantics allow value types to be used like reference types.

* `in` parameters
  - This method doesn't modify the value of the argument used as this parameter.
  - Unlike a ref or out parameter, you don't need to apply the in modifier at the call site.
  - Use in parameters for large structs.
  - Avoid defensive copies.
  - The in modifier can also be used with reference types or numeric values. However, the benefits in those cases are minimal, if any.
* `ref` returns
  - Returns a reference to value type, not a copy of the value
  - Lifetime of the returned value must exceed the lifetime of the called method, e.g. a reference to a field or method argument, NOT a variable in the called method (also not allowed on `async` methods)
  - Modifying this reference is the same as modifying the original value
  - Add `ref` modifier to the method declaration return type, and to `return` statement
* `ref` local  
  - Assigning a `ref` return to a new variable will create a copy (The variable is a value type, not a reference!)
  - A `ref` local is a variable that is a reference to a value tupe. Accessing the variable accesses the original value
  - Use a `ref` local to store the `ref` return result
  - Type inference with `var` will get the value type, not the `ref` modifier - requires `ref var` to work as expected
* `ref readonly` returns
  - Extends `ref` locals and returns
  - Return a value type by reference, but caller is not allowed to modify  
* `readonly` struct
  - Indicates that a type is immutable.
  - All field members must be read-only.
  - All properties must be read-only, including auto-implemented properties.  
* `ref struct`
  - Use a ref struct or a readonly ref struct, such as Span<T> or ReadOnlySpan<T>, to work with blocks of memory as a sequence of bytes.
--- 
## Pass By Reference VS Value

| Pass By Reference | Pass By Value |
|:---|:---|
| A variable of a reference type is a refernce to the actual object on the heap | A variable for a value type is the value inself |
| Passing a reference type to a method is just passing this reference | Passing a value type to a method _copies_ the value |
| The caller and the called method see the same object on the heap |  |
|  | Assigning a value type to a new variable also _copies_ the value |
|  | Original value is unmodified |
|  | (Copies aren't actually that expensive) |

---
## Using value types minimizes the number of allocation operations:
*  Storage for value types is stack-allocated for local variables and method arguments.
*  Storage for value types that are members of other objects is allocated as part of that object, not as a separate allocation.
*  Storage for value type return values is stack allocated.

## Contrast that with reference types in those same situations:
* Storage for reference types is heap allocated for local variables and method arguments. The reference is stored on the stack.
* Storage for reference types that are members of other objects are separately allocated on the heap. The containing object stores the reference.
* Storage for reference type return values is heap allocated. The reference to that storage is stored on the stack.
---
## Links:
* [Write safe and efficient C# code](https://learn.microsoft.com/en-us/dotnet/csharp/write-safe-efficient-code)
