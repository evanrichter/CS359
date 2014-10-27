//Get the first item in a list of integers
let getFirst li =
    match li with
    | hd :: tl -> hd
    | [] -> 0

//Return true if a list is empty
let isEmpty li =
    match li with
    | [] -> true
    | _ -> false

//Return true if a list contains exactly one element
let oneElement li =
    match li with
    | [only] -> true
    | _ -> false

//Return true if a list contains exactly two elements
let twoElements li =
    match li with
    | hd1 :: hd2 :: [] -> true
    | _ -> false

//Return true if a list contains exactly two elements
let twoElementsAlternate li =
    match li with
    | [firstOne; secondOne] -> true
    | _ -> false

//Take a list.  Return another list with the first element changed to 99
let changeFirstTo99 li =
    match li with
    | hd :: tl -> 99 :: tl





    