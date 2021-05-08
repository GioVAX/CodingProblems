module CoinChange

let standardCoinSizes = [1; 2; 5; 10; 50]

let append coin =
    List.map (fun l -> coin::l)

let generateAllChanges previousIteration newCoin =
    previousIteration
    |> Map.fold
        (fun currentIteration amnt oldChanges ->
            match (amnt, oldChanges) with
            | (amount, changes) when amount < newCoin -> 
                currentIteration 
                |> Map.add amount changes
            | (amount, [[]]) -> 
                currentIteration
                |> Map.add amount (append newCoin currentIteration.[amount - newCoin])
            | (amount, changes) ->
                let withCoin = (append newCoin currentIteration.[amount - newCoin])
                let allChanges = changes |> List.append withCoin
                currentIteration
                |> Map.add amount allChanges
        )
        Map.empty

let leastCoins l =
    l
    |> List.sortBy List.length
    |> List.head

let customChange availableSizes amount =
    let initial = 
        [0..amount] |> List.fold (fun m i -> Map.add i ([[]]:int list list) m) Map.empty
    let changes = 
        availableSizes
        |> List.fold generateAllChanges initial
    changes.[amount]

let change amount = 
    customChange standardCoinSizes amount
    |> leastCoins