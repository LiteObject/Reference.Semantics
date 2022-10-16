# C# Reference Semantics with Value Types
* `in` parameters
  - This method doesn't modify the value of the argument used as this parameter.
  - Unlike a ref or out parameter, you don't need to apply the in modifier at the call site.
  - Use in parameters for large structs.
  - Avoid defensive copies.
  - The in modifier can also be used with reference types or numeric values. However, the benefits in those cases are minimal, if any.
* `ref` locals and returns
* `ref readonly` returns
  - The return value is a struct larger than [IntPtr.Size](https://learn.microsoft.com/en-us/dotnet/api/system.intptr.size?view=net-6.0).
  - The storage lifetime is greater than the method returning the value.
* `readonly` struct
  - Indicates that a type is immutable.
  - All field members must be read-only.
  - All properties must be read-only, including auto-implemented properties.  
* `ref struct`
  - Use a ref struct or a readonly ref struct, such as Span<T> or ReadOnlySpan<T>, to work with blocks of memory as a sequence of bytes.
  
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
