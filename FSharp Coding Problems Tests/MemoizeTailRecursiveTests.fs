module MemoizeTailRecursiveTests

open System.Collections.Generic

let memoizeTR func2Memoize =
    let cache = Dictionary<_,_>()

    let rec loop param cont =
        let storeAndContinue res = 
            cache.Add(param, res) 
            cont res

        match cache.TryGetValue(param) with
        | true, res -> cont res
        | _ -> func2Memoize param storeAndContinue loop

    cache, (fun param -> loop param id)

let TRFactorial param cont memoFunction =
    match param with
    | 0 -> 1
    | _ -> 
        memoFunction 
            (param-1) 
            (fun r1 -> 
                let r = r1 * param
                cont r) 

let factorialCache, memoizedTRFactorial = memoizeTR TRFactorial