//list practice


let rec getLast li =
  match li with
  |[x] -> x
  |h::t -> getLast t


//get all but last element of a list
let rec forgetLast li =
  match li with
  |[x] -> []
  |h::t -> h::forgetLast t

let rec isPalendrome li =
  match li with
  |[x] -> "true"
  |[x;y] when x = y -> "true"
  |h::t when h = getLast t -> isPalendrome (forgetLast t)
  |_ -> "false"


let rec repLetter x n =
    match n with
    |0 -> null
    |_ -> x + (repLetter x (n-1))

let abString a b =
    (repLetter "a" a) + (repLetter "b" b)

let rec repeat x n =
    match n with
    |0 -> []
    |_ -> x::(repeat x (n-1))

let rec replicateElements li n =
    match li with
    |[] -> []
    |h::t  -> (repeat h n) @ (replicateElements t n)

let rec removeKthElement li (k:int) =
    match li, k with
    |[one], 1 -> []
    |h::t, 1 -> t
    |h::t, _ -> h::(removeKthElement t (k-1))

let createListRange lo hi step =
    [lo..step..hi]
