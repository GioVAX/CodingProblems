[<AutoOpen>]
module Commons

let primeFactors n = 
    let rec getFactors prime acc (num:int64) = 
        if prime = num then
            prime::acc
        elif num % prime = 0L then 
            getFactors prime (prime::acc) (num/prime)
        else
            getFactors  (prime+1L) acc num
    getFactors 2L [] n