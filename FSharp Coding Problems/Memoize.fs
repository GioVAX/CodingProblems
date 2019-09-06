module Memoize

let memoize f =
    let mutable cache = Map.empty
    (fun param -> 
        match cache.TryFind param with
        | Some value -> value
        | None -> 
            let value = f param
            let cache = cache.Add (param, value)
            value
    )

