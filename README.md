# StringExpression
## Project setup and folder structure
This is a .NET 7 based Web API project that has only one Controller MathExpressionController. The Controller has only one HttpPost method that takes the mathematical expression as a string from the request body. The application has a service called DmasService that contains the business logic, keeping the controller code clean. The solution has a validators folder containing a validator to validate the expression, an enum for operators    
## Logic / Algorithm
1- The controller action method 'Evaluate' receives the string mathematical expression and forwards it to the service method 'Evaluate'. The service is injected into the controller through .NET dependency injection container configured in the Program.cs class.    
2- The service method on receiving the string expression first validates and checks if the expression is valid or not. I have added some basic validation to check if the expression is null or empty and if it starts and ends with a digit. If validation fails, an exception is thrown indicating that the expression is not valid.    
3- If the expression is valid, I use the DMAS (Division > Multiplication > Addition > Subtraction) rule to solve the expression.    
4- The expression is solved using recursion.    
5- Firstly, based on a regular expression, I check if the expression has a division sign '/' in it. If the division sign is present. I get the number to its left (num1) and right (num2) and apply division num1/num2. Once I have the division result, I update the original expression with the result of the division. For example:     
**Original expression = 4+5/2**  ==after applying division==>  **New expression = 4+2.5**    
6- Now the new expression is passed to the same Evaluate service method to be further evaluated.    
7- On the recursion, it will again check if there are more division '/' signs to be solved. If not, it will move to the next block where it checks for multiplication signs '*'. If a multiplication sign is found in the expression, it will get the left (num1) and right (num2) of the multiplication sign and perform multiplication on them. The result of the multiplication will then be placed in place of the multiplication expression in the string expression. For example:    
**Original expression = 4+5*****2**  ==after applying division==>  **New expression = 4+10**    
8- The exact same process is followed for Addition and Subtraction. Addition or subtraction is performed and the result is placed in the place of the addition/subtraction expression in the original expression.    
9- The expression is solved using recursion. The 'else' condition in the Evaluate service method is the break condition for recursion where it parses the result to decimal from the string and returns the result.   

## Testing    
I have used the xUnit NuGet package for writing unit tests. Tests cover valid, invalid expression, and exception scenarios.    

    
<img width="572" alt="image" src="https://github.com/mali153048/StringExpression/assets/34284730/c89f717f-a674-4dba-8d6f-f9add5e81f80">


