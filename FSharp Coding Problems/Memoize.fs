module Memoize

open System.Collections.Generic

let memoize f =
    let cache = Dictionary<_, _>()
    (fun param -> 
        match cache.TryGetValue param with
        | true, value -> value
        | false, _ -> 
            let value = f param
            cache.Add (param, value)
            value
    )