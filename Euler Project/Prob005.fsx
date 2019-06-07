module Prob005
open System

#load "Commons.fsx"

// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
//
// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?

// Notes: 2520 = 2^3 * 3^2 * 5 * 7
// the solution is a mcm on multiple numbers (rather than just 2)

type Base = Base of int
type Power = Power of int

[<CustomComparison>]
[<StructuralEquality>]
type Factor = 
    | Factor of (Base * Power)

    interface System.IComparable with
        member this.CompareTo y = 
            match y with
            | :? Factor as that ->
                let (Factor(Base b1,_)) = this
                let (Factor(Base b2,_)) = that
                compare b1 b2
            | _ -> failwith "Arguments are different"            

let findFactor bas =
    Set.filter (fun (Factor (b, _)) -> b = bas )
    >> Seq.item 0

let mergeFactors f1 f2 =
    let highestPower (Factor(b,_ )) = 
        let (Factor (_,Power p1)) = f1 |> findFactor b
        let (Factor (_,Power p2)) = f2 |> findFactor b
        Factor (b, Power (Math.Max(p1, p2)))

    let commons = Set.intersect f1 f2
    let justInF1 = f1 - commons
    let justInF2 = f2 - commons

    (commons |> Set.map highestPower) 
        + justInF1 
        + justInF2
    
let toFactorSet n =
    let cnv = 
        int64 
        >> primeFactors 
        >> List.map int 
        >> List.groupBy id 
        >> List.map (fun (b, pow) -> Factor(Base b, Power (List.length pow)))
        >> Set.ofSeq
    cnv n

let solution =
    List.map toFactorSet 
    >> List.fold mergeFactors Set.empty
    >> Set.fold (fun tot (Factor (Base b, Power p)) -> tot * Math.Pow(float b, float p) ) 1.0