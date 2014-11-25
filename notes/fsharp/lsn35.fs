// insertAt: insert a value into the given list at the given position, return the resulting list
// index at 1
let rec insertAt list i value =
    match i with
    |1 -> value::list
    |_ -> List.head list :: (insertAt (List.tail list) (i-1) value)

// getLast element in a list
let rec getLast list =
    match list with
    |[a] -> a
    |h :: t -> getLast t

// penultimate (second to last)
let rec chopOffLast list =
    match list with
    |[a] -> []
    |h::t -> h :: chopOffLast t

let penultimate list = chopOffLast (getLast list)