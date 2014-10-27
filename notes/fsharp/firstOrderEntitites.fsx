//Write a function that applies another function to an integer and returns the
//result as a string.  Don't forget to use string x to get the string
//representation of x
let applyAndConvertToString (f : int->int) x =
    string (f x)


//Write a function that takes an integer and adds six to it
let addSix n =
    n + 6

//Write a function that takes an integer and raises it to the 4th power
let raiseTo4th n =
    pown n 4



//Write a function that applies a function to all elements of a list
let rec applyToAll f li =
  match li with
  |[] -> []
  |h::t -> f h::applyToAll f t

























//Write a function that applies a function to all elements of a list
let rec applyToAll func li =
    match li with
    | [] -> []
    | hd :: tl -> func hd :: applyToAll func tl

