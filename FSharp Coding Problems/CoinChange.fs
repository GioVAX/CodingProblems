module CoinChange

let CoinSizes = [1; 2; 5; 10; 50]

let customChange (sizes:int list) (amount:int) : int list =
    let found = 
        sizes
        |> List.tryFind (fun s -> s = amount)
    match found with
    | Some(_) -> [amount]
    | None -> []

let change amount = customChange CoinSizes amount