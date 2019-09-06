module PE_Prob010

open PE_Commons

// The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
// 
// Find the sum of all the primes below two million.

let solution n =
    let nums = 
        primes
        |> Seq.takeWhile (fun p -> p < n)
    
    nums 
    |> Seq.sumBy int64