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
    change 3
    |> should matchList [1;2]