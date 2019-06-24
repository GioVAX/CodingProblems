module Prob014

// The following iterative sequence is defined for the set of positive integers:
//
//                  n → n/2 (n is even)
//                  n → 3n + 1 (n is odd)
//
// Using the rule above and starting with 13, we generate the following sequence:
//
//                  13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
// It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms.
// Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.
//
// Which starting number, under one million, produces the longest chain?
//
// NOTE: Once the chain starts the terms are allowed to go above one million.

let mutable collatzMemoize = Map.empty<int, int list>

let rec collatz n =
    let ret = match n |> collatzMemoize.TryFind with
                | Some list -> n::list
                | None -> match n with
                            | 1 -> [1]
                            | e when e % 2 = 0 -> n::(collatz (e/2))
                            | o -> n::(collatz (o*3+1))
    collatzMemoize <- collatzMemoize.Add (n, ret) 
    ret

let rec collatz' n = 
    seq { 
        yield n
        match n with 
        | 1 -> yield! []
        | e when e % 2 = 0 -> 
            yield! collatz' (e / 2)
        | o -> 
            yield! collatz' (o * 3 + 1)
    }

let resetCollatz = collatzMemoize <- Map.empty<int, int list>

let solution maxNum =
    resetCollatz
    [1..maxNum]
        |> Seq.map (fun n -> (n, n |> collatz |> Seq.length))
        |> Seq.maxBy snd

let solution' maxNum =
    [1..maxNum]
        |> Seq.map (fun n -> (n, n |> collatz' |> Seq.length))
        |> Seq.maxBy snd
            