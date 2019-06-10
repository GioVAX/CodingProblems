// From https://en.wikibooks.org/wiki/F_Sharp_Programming/Lists

module MixedProblemsLists

let pair = 
    let rec loop = function
        | []  
        | [_] -> []
        | fst::snd::tail -> (fst, snd)::loop tail
    loop

// let pair' l = 
//     let rec loop acc = function
//         | []  | [_] -> List.rev acc
//         | first::second::tail -> loop ((first, second) :: acc) tail
//     loop [] l   

let unpair =
    let rec loop = function
        | [] -> []
        | (fst,snd)::tail -> fst::snd::loop tail
    loop    

let expand =
    let rec loop = function
        | [] -> []
        | (_::tail) as list -> list::loop tail
    loop

let gcdEuclid n1 n2 =
    let rec loop big small = 
        match big % small with
        | 0 -> small
        | rem -> loop small rem

    if n1 > n2 then
        loop n1 n2
    else
        loop n2 n1    

let gcdl = function
        | [] -> 0
        | list -> List.reduce gcdEuclid list

let msort =
    let split (l: 'a list) = List.splitAt (l.Length / 2) l
    let rec merge (list1, list2) = 
        match(list1,list2) with
        | (list1, []) -> list1
        | ([], list2) -> list2
        | (h1::t1, h2::_) when h1 < h2 -> h1::merge (t1, list2)
        | (list1, h2::t2) -> h2::merge (list1, t2)
    let rec loop = function
        | [] -> []
        | [item] -> [item]
        | list -> 
            let (l1, l2) = split list
            merge (loop l1, loop l2)
    loop

