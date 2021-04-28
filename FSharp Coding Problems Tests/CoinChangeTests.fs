module CoinChangeTests

open Xunit
open FsCheck
open FsCheck.Xunit
open FsUnit.Xunit

open CoinChange

type OneCoin = 
    static member x()=
        Gen.elements CoinSizes
        |> Arb.fromGen

[<Property(Arbitrary=[| typeof<OneCoin> |])>]
let ``change for one of the available sizes SHOULD return one elem of the size`` (coin:int) =
    change coin
    |> should equal [coin]