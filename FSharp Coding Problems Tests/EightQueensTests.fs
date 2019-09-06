module EightQueensTests

open Xunit
open FsCheck
open FsCheck.Xunit

open EightQueens
open TestDataGenerator

[<Property(Verbose=true)>]
let ``Bishop fails on same column`` ({Row=_; Col=col} as coord) =
    Prop.forAll (sameColumnGenerator coord) (fun coord2 -> bishopCanCapture coord coord2 = false)
