let rec repLetter l n =
    match n with
    |0 -> ""
    |_ -> l + repLetter l (n-1)

let abString a b =
    (repLetter "a" a) + (repLetter "b" b)


let rec removeKthElement li k =
    match k with
    |1 -> List.tail li
    |_ -> List.append [List.head li] (removeKthElement (List.tail li) (k-1))
