module Prob015Tests

open Xunit
open FsUnit.Xunit

open PE_Prob015

[<Fact>]
let ``valid paths for a 1x1 grid SHOULD be 2`` () =
    solution 1
    |> should equal 2

[<Fact>]
let ``valid paths for a 2x2 grid SHOULD be 6`` () =
    solution 2
    |> should equal 6

[<Fact>]
let ``valid paths for a 3x3 grid SHOULD be 20`` () =
    solution 3
    |> should equal 20
