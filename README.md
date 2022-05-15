# Trillium

[![Generic badge](https://img.shields.io/badge/IDE-VS2022-blue.svg)](https://shields.io/)
[![Generic badge](https://img.shields.io/badge/C%23-10%2E0-blue.svg)](https://shields.io/)
[![Generic badge](https://img.shields.io/badge/%2ENet%20Core-6%2E0-blue.svg)](https://shields.io/)

![license](https://img.shields.io/github/license/ReserveBlockIO/Trillium)
![build](https://img.shields.io/github/workflow/status/ReserveBlockIO/Trillium/.NET)
![issues](https://img.shields.io/github/issues/ReserveBlockIO/Trillium)
![Discord](https://img.shields.io/discord/917499597692211260?label=discord)

![GitHub commit activity](https://img.shields.io/github/commit-activity/m/ReserveBlockIO/Trillium)
![GitHub last commit](https://img.shields.io/github/last-commit/ReserveBlockIO/Trillium)

![GitHub Release Date](https://img.shields.io/github/release-date/ReserveBlockIO/Trillium)

Trillium is the smart contract language that will be powering our smart contracts. This is a from scratch language that has roots from C#, C, and some Javascript.

# Core Features (Statements, expressions, etc)

This language is turing complete and has many features. Below are most of the current implemented features:
- Numbers (ints)
- Strings ("Any")
- Booleans (true, false)
- Addition ('+')
- Subtraction ('-')
- Multiplication ('*')
- Division ('/')
- Basic Operator Tokens(&, !, ^, |, =, (, ), >, <, [, ], :, ',', &&, !=, ^=, ==, >=, <=, and more)
- If Statements
- Else Statements
- Else If Statements
- Returns
- While Loops
- For Loops
- Do While Statements
- Block Statements
- Expressions
- Variable Declaration
- LiteralExpression,
- Name Expression
- Unary Expression
- Binary Expression
- Parenthesized Expression
- Assignment Expression
- Call Expression

# Examples

The Languages purpose is to drive all self-executing NFT (SENs) functions. 

Some examples are below:
```
function HelloPerson(name : string) : string
{
    var text = "Hello " + name
    return text
}
HelloPerson("Trillium")
```
_outputs Hello Trillium_

```
12 + 12 -> press enter
```
_outputs 24_

```
function WhoAmI(age : int, name : string)
{
    if name == "Trillium" && age == 99
    {
        print("Hi " + name)
    }
    else
    {
        print("Hello, sorry but we don't know you")
    }
}
```
_outputs "Hi Trillium" if name = "Trillium" and age = 99_
_outputs "Hello, sorry but we don't know you" for everything else_

You can define variables as such:
```
{
    var name : string = "Some Name" (or var name = "Some Name")
    var number : int  = 22 (or var number = 22)
    var truth : bool = true (or var truth = true)
}
```

Lets make a basic two number calculator where we pass in the operator as a string
```
function calculator(firstNum : int, secondNum : int, operator : string) : string
{
    var result = 0
    if operator == "+"
    {
        result = firstNum + secondNum
        return string(result)
    }
    else if operator == "-"
    {
        result = firstNum - secondNum
        return string(result)
    }
    else if operator == "*"
    {
        result = firstNum * secondNum
        return string(result)
    }
    else if operator == "/"
    {
        result = firstNum / secondNum
        return string(result)
    }
    else 
    {
        return "No known operator was given"
    }
}

calculator(2, 2, "+") 
```
_output is 4_

![image](https://user-images.githubusercontent.com/20599614/168458348-52a33585-0600-4070-9dec-7110809fb5d2.png)
![image](https://user-images.githubusercontent.com/20599614/168458326-18e65a71-4554-4de7-ad3a-7420cc180be1.png)

Trillium is constantly growing and will evolve over time to support more functions and have more built in features to reduce code writing.

# Things to do

- Emit IL
- Nullable types
- Comments (May not do this to keep source code files smaller)

# Setup

- Install Visual Studio 2022 or latest version of Visual Code
- .Net Core 6
- Download the Trillium repo from GitHub
- Open the Trillium.sln file in Visual Studio or open the src folder in VS Code

# Testing
To write and test your own contracts first follow the setup instructions above. Next you will want to run the TrilliumI project. This will open the REPL in the CLI and allow you to being writing natively in Trillium and getting results. The REPL provides full diagnostics, so you will know exactly what is wrong within your statements of code.

# Who do I talk to? ###

- Repo owner or admin
- Other community or team contact
- https://discord.gg/PnS2HRETDh

# People to Thank and Sources

The language was modeled after the language courses from Microsoft's Immo Landwerth and adapted further to work within the ReserveBlocks core wallet infastructure.

Some other references to site are (please note none of these people worked on the project, but rather provided material to help make this. They are in no way affiliated with this project):

- Clinton L. Jeffery and his Books
- Jon Skeet and his C# In Depth books
- Alex Williams and his debugging methodology
- Immo Landwerth and his series

# License

Trillium is released under the terms of the MIT license. See [COPYING](COPYING) for more
information or see https://opensource.org/licenses/MIT.
