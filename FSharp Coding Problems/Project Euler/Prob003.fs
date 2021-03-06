module PE_Prob003

open PE_Commons

// The prime factors of 13195 are 5, 7, 13 and 29.
//
// What is the largest prime factor of the number 600851475143 ?

let solution num =
    primeFactors num
    |> List.sortDescending
    |> List.take 1    