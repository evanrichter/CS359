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