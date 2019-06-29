module MixedProblemsTests

open Xunit
open FsUnit.Xunit
open FsCheck
open FsCheck.Xunit

open MixedProblemsLists

let listOfLength len = Gen.listOfLength len Arb.generate |> Arb.fromGen

[<Fact>]
let ``pair of an empty list should return an empty list`` () =
    pair []
    |> should be Empty

[<Fact>]
let ``pair of an one element list should return an empty list`` () =
    Prop.forAll (listOfLength 1) (fun ls -> ls |> pair |> List.length = 0)
        |> Check.QuickThrowOnFailure 

[<Property>]
let ``pair of an even-length list should return the right number of pairs`` ( nums: int list ) =
    (List.length nums) % 2 = 0 ==>
    let pairs = pair nums
    (pairs.Length * 2) = nums.Length

//[<Property>]
//let ``test even length`` ( listSize ) =
//    let testFunction (list: int list) =
//        let result = pair list
//        result.Length * 2 = list.Length

//    let evenLenList = listOfLength (2*listSize)

//    Prop.forAll evenLenList testFunction
//        |> Check.QuickThrowOnFailure 

[<Property>]
let ``pair of an odd-length list should return the right number of pairs`` ( nums: int list ) =
    (List.length nums) % 2 = 1 ==>
    let pairs = pair nums
    (pairs.Length * 2) = nums.Length - 1

[<Property>]
let ``pair of an even-length list should return the right pairs`` ( nums: int list ) =
    (List.length nums) % 2 = 0 ==>
    let pairs = pair nums
    let rebuilt = pairs |> List.fold (fun list (n1, n2) -> n2::n1::list) [] |> List.rev
    nums = rebuilt

[<Property>]
let ``pair of an odd-length list should return the right pairs except the last element`` ( nums: int list ) =
    (List.length nums) % 2 = 1 ==> 
    lazy
        let pairs = pair nums
        let rebuilt = pairs |> List.fold (fun list (n1, n2) -> n2::n1::list) []

        rebuilt= (nums |> List.rev |> List.tail)

[<Property>]
let ``pair and unpair of an even-length list should return the original list`` ( nums: int list ) =
    (List.length nums) % 2 = 0 ==>
    ((unpair (pair nums)) = nums)

[<Property>]
let ``pair and unpair of an odd-length list should return the original list except the last element`` ( nums: int list ) =
    (((List.length nums) > 1) && ((List.length nums) % 2 = 1)) ==>
    lazy
        let allButLast = nums |> List.rev |> List.tail |> List.rev
        ((unpair (pair nums)) = allButLast)
    
    