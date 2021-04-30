module CoinChangeTests

open Xunit
open FsCheck
open FsCheck.Xunit
open FsUnit.Xunit

open CoinChange

type OneCoin = 
    static member x()=
        Gen.elements standardCoinSizes
        |> Arb.fromGen

[<Property(Arbitrary=[| typeof<OneCoin> |])>]
let ``change for one of the available sizes SHOULD return one elem of the size`` (coin:int) =
    change coin
    |> should equal [coin]

[<Fact>]
let ``change for 3 SHOULD return 1 and 2`` ()=
    customChange standardCoinSizes 3
    |> should matchList [[2;1] ; [1;1;1]]

[<Fact>]
let ``change for 5`` ()=
    customChange standardCoinSizes 5
    |> should matchList [[5]; [2;2;1]; [2;1;1;1]; [1;1;1;1;1]]

[<Property>]
let ``index less than coin is unchanged`` (pre: int list list) =
    let result =
        generateAllChanges [|pre|] 1

    result.[0] |> should matchList pre

[<Property(Arbitrary=[| typeof<OneCoin> |])>]
let ``on empty list return the coin`` (coin:int) =
    let state = Array.create (coin+1) [[]]
    let result = generateAllChanges state coin

    let expected = Array.create (coin+1) [[]]
    expected.[coin] <- [[coin]]
    result |> should equal expected

[<Fact>]
let ``change of 2 with only 1s`` () =
    let state = Array.create 3 [[]]
    let result = generateAllChanges state 1

    result |> should equal [| [[]]; [[1]]; [[1;1]] |]