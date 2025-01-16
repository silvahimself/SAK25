# SAK25

SAK25 is a .NET library providing a variety of extension methods and utilities for character manipulation, collections, strings, dates, and environment helpers.

### Releases

[![Build Status](https://github.com/silvahimself/sak25/actions/workflows/dotnet-desktop.yml/badge.svg?branch=master)](https://github.com/silvahimself/SAK25/actions/workflows/dotnet-desktop.yml) [![NuGet version](https://img.shields.io/nuget/v/SAK25.svg?style=flat&label=nuget%20version)](https://www.nuget.org/packages/SAK25/)

## Features

- Extension methods for characters, collections, and strings.
- Utility methods for file and environment operations.
- Simplified handling of common tasks like parsing arrays, grouping data, and validating input.

---

## Installation

Add the SAK25 library to your .NET project using the NuGet Package Manager:

```bash
Install-Package SAK25
```

---

## Usage

### Character Extensions

#### `IsSpecialCharacter(char c)`

Checks if a character is a special character (not a letter or number).

<details>
<summary>Usage: Check for special characters</summary>

```csharp
using SAK25.Extensions;

char example = '@';
bool isSpecial = example.IsSpecialCharacter();
```

</details>

### Collection Extensions

#### `RandomElement<T>(IEnumerable<T> collection)`

Retrieves a random element from an enumerable. Complexity: **O(n)**.

<details>
<summary>Usage: Get random element from a collection</summary>

```csharp
using SAK25.Extensions;

var collection = new List<int> { 1, 2, 3, 4 };
var randomElement = collection.RandomElement();
```

</details>

#### `RandomElement<T>(T[] array)`

Retrieves a random element from an array. Complexity: **O(1)**.

<details>
<summary>Usage: Get random element from an array</summary>

```csharp
using SAK25.Extensions;

int[] array = { 1, 2, 3, 4 };
var randomElement = array.RandomElement();
```

</details>

#### `Fill(char[] array, char c)`

Fills a character array with the specified character (default: '0'). Complexity: **O(n)**.

<details>
<summary>Usage: Fill a character array</summary>

```csharp
using SAK25.Extensions;

char[] array = new char[5];
array.Fill('X');
```

</details>

#### `Fill(char[][] array, int xSize, int ySize, char c)`

Fills a two-dimensional character array with the specified character (default: '0'). Complexity: **O(xSize*ySize)**.

<details>
<summary>Usage: Fill a 2D character array</summary>

```csharp
using SAK25.Extensions;

char[][] array = new char[3][];
for (int i = 0; i < 3; i++)
{
    array[i] = new char[4];
}
array.Fill(3, 4, 'Y');
```

</details>

#### `ParseArray(IEnumerable<string> data)`

Transforms a string enumerable into an integer array.

<details>
<summary>Usage: Parse string enumerable to integer array</summary>

```csharp
using SAK25.Extensions;

var stringData = new List<string> { "1", "2", "3" };
int[] intArray = stringData.ParseArray();
```

</details>

#### `GroupedInDictionary(int[] numbers)`

Counts occurrences of each integer in an array, returning the result as a dictionary.

<details>
<summary>Usage: Group integers into a dictionary</summary>

```csharp
using SAK25.Extensions;

int[] numbers = { 1, 2, 2, 3 };
var grouped = numbers.GroupedInDictionary();
```

</details>

### DateTime Extensions

#### `YearsElapsed(DateTime date)`

Calculates the number of years elapsed since a specified date.

<details>
<summary>Usage: Calculate years elapsed</summary>

```csharp
using SAK25.Extensions;

DateTime pastDate = new DateTime(2000, 1, 1);
int yearsElapsed = pastDate.YearsElapsed();
```

</details>

### String Extensions

#### `IsANumber(char c)`

Checks if a string is a number.

<details>
<summary>Usage: Check if character is a number</summary>

```csharp
using SAK25.Extensions;

char character = '5';
bool isNumber = character.IsANumber();
```

</details>

#### `IsEmailAddress(string s)`

Validates if a string is a valid email address.

<details>
<summary>Usage: Validate email address</summary>

```csharp
using SAK25.Extensions;

string email = "example@test.com";
bool isValid = email.IsEmailAddress();
```

</details>

#### `Minified(string s)`

Minifies a string by removing all spaces, tabs, newlines, and carriage returns.

<details>
<summary>Usage: Minify a string</summary>

```csharp
using SAK25.Extensions;

string text = "Hello \n World \t!";
string minified = text.Minified();
```

</details>

#### `Fill(string s, int size, string chars)`

Fills a string with the specified character until it reaches the desired size.

<details>
<summary>Usage: Fill string to desired size</summary>

```csharp
using SAK25.Extensions;

string text = "Test";
string filled = text.Fill(10, "*");
```

</details>

#### `AsStream(string s)`

Converts a string into a `MemoryStream`.

<details>
<summary>Usage: Convert string to MemoryStream</summary>

```csharp
using SAK25.Extensions;

string text = "Hello World";
using var stream = text.AsStream();
```

</details>

#### `FillRandom(string s, RandomStringParams stringParams)`

Fills a string with random characters up to a specified size (default: 32).

<details>
<summary>Usage: Fill string with random characters</summary>

```csharp
using SAK25.Extensions;

string example = "Hello";
string randomFilled = example.FillRandom(10);
```

</details>

### Helpers

#### Environment Helpers

##### `EnvVar(string name)`

Retrieves the value of an environment variable from the current process, user, or machine variables.

<details>
<summary>Usage: Retrieve environment variable</summary>

```csharp
using SAK25.Helpers;

string path = EnvironmentHelpers.EnvVar("PATH");
```

</details>

##### `ExecutingDir`

Gets the directory where the application is executing.

<details>
<summary>Usage: Get executing directory</summary>

```csharp
using SAK25.Helpers;

string executingDir = EnvironmentHelpers.ExecutingDir;
```

</details>

##### `BinDir`

Gets the bin directory of the project.

<details>
<summary>Usage: Get bin directory</summary>

```csharp
using SAK25.Helpers;

string binDir = EnvironmentHelpers.BinDir;
```

</details>

##### `ProjectDir`

Gets the project directory.

<details>
<summary>Usage: Get project directory</summary>

```csharp
using SAK25.Helpers;

string projectDir = EnvironmentHelpers.ProjectDir;
```

</details>

#### File Helpers

##### `GetAllFilesRecursive(string path, FileSearchOptions options)`

Recursively retrieves all files and directories in a given path.

<details>
<summary>Usage: Retrieve all files recursively</summary>

```csharp
using SAK25.Helpers;

var files = FileHelpers.GetAllFilesRecursive("/path/to/dir", new FileSearchOptions());
```

</details>

---

## Contributing

Contributions are welcome! Please submit issues or pull requests with clear commit messages, and in small chunks.

---

## License

This library is licensed under the MIT License. See `LICENSE` for details.
