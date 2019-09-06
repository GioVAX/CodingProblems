module PE_Commons

let primeFactors n = 
    let rec getFactors prime acc (num:int64) = 
        if prime = num then
            prime::acc
        elif num % prime = 0L then 
            getFactors prime (prime::acc) (num/prime)
        else
            getFactors  (prime+1L) acc num
    getFactors 2L [] n

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