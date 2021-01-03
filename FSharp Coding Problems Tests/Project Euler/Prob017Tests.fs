module Prob017Tests

open Xunit
open FsUnit.Xunit

open EulerProb017

[<Fact>]
let ``length of numbers to n should be res`` () =
    solution 5
    |> should equal 19I

[<Theory>]
[<InlineData(5,"five")>]
[<InlineData(45,"forty-five")>]
[<InlineData(342, "three hundred and forty-two")>]
[<InlineData(115, "one hundred and fifteen")>]
let ``toLetters works`` (n, res) =
    toLetters n
    |> should equal res

[<Theory>]
[<InlineData(342,23)>]
[<InlineData(115,20)>]
let ``normalised lenght of n is res`` (n, res) =
    n 
    |> (toLetters >> normalize >> String.length)
    |> should equal res
