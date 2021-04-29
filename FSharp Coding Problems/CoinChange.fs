module CoinChange

let standardCoinSizes = [1; 2; 5; 10; 50]

// array[1...amount] of list of coins
// iterate over coinSizes to add the new coin

let private loop (array:int list []) coin = 
    let createCouples coin amn l =
        if amn < coin
        then [l]
        else [l; coin::array.[amn-coin]]
    
    array
    |> Array.mapi (createCouples coin)
    |> Array.map (fun ill -> ill |> List.filter (fun l-> l.Length > 0) |> List.minBy List.length)

let customChange (sizes:int list) (amount:int) : int list =
    let found = 
        sizes
        |> List.tryFind (fun s -> s = amount)

    match found with
    | Some(_) -> [amount]
    | None ->
        let init = Array.create (amount+1) []
        let state = 
            standardCoinSizes
            |> List.fold loop init
        state.[amount]

let change amount = customChange standardCoinSizes amount