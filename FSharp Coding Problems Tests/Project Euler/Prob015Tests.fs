module Prob015Tests

open Xunit
open FsUnit.Xunit

open EulerProb015

[<Theory>]
[<InlineData(1,2)>]
[<InlineData(2,6)>]
[<InlineData(3,20)>]
[<InlineData(5,252)>]
[<InlineData(7,3432)>]
let ``valid paths for a n*n grid SHOULD be res`` (n,res:int) =
    solution n
    |> should equal (bigint res)