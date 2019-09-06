module PE_SProb014

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

let nextStep (cycle, n :int64) =
    match n with
    | _ when n % 2L = 0L -> (cycle + 1, n / 2L)
    | _ -> (cycle + 1, n * 3L + 1L)


let rec loop cycle n =
    match n with
    | 1L -> cycle
    | _ -> 
        // if n > 0L then printf "%d\n" n
        let (nc,nn) = nextStep (cycle, n)
        loop nc nn

let solution max =
    let lengths =
        [1L..max] 
        |> List.map (fun n -> n, (loop 1 n))

    lengths |> Seq.maxBy snd
