module Prob003

// The prime factors of 13195 are 5, 7, 13 and 29.
//
// What is the largest prime factor of the number 600851475143 ?

let rec primeFactors prime acc (num:int64) = 
    if prime = num then
        prime::acc
    elif num % prime = 0L then 
        primeFactors prime (prime::acc) (num/prime)
    else
        primeFactors  (prime+1L) acc num

let solution num =
    primeFactors 2L [] num
    |> List.sortDescending
    |> List.take 1    