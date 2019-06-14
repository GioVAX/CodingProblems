module Prob007

// By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
//
// What is the 10 001st prime number?

let primes =
    let rec loop prevs newVal=
        if prevs |> List.forall (fun p -> newVal % p <> 0) then
            seq { 
                yield newVal;
                yield! loop (newVal::prevs) (newVal+1)
            }
        else        
            seq {
                yield! loop prevs (newVal+1)
            }
    loop [] 2

let solution n =  primes |> Seq.take n |> Seq.last