module PE_Prob001

// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
//
// Find the sum of all the multiples of 3 or 5 below 1000.

let calculateMultiples num =
    fun startNum -> seq { for i in num .. num .. startNum -> i }

let solution max =
    let mult3 = calculateMultiples 3 max
    let mult5 = calculateMultiples 5 max
    let nums = Seq.append mult3 mult5 |> Seq.distinct
    nums |> Seq.sum