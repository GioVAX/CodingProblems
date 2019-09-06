module PE_Prob006

// The sum of the squares of the first ten natural numbers is,
//              1^2 + 2^2 + ... + 10^2 = 385
//
// The square of the sum of the first ten natural numbers is,
//           (1 + 2 + ... + 10)^2 = 55^2 = 3025
//
// Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
//
// Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.

let square (x:int) = x * x

let sumOfNums start endd =
    [start .. endd]
    |> List.sum

let solution num =
    let sumOfSquares = 
        [1..num]
        |> List.sumBy square
    let squareOfSum =
        [1..num]
        |> List.sum
        |> square
    System.Math.Abs (sumOfSquares - squareOfSum)